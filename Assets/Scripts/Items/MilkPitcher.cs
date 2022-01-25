using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Dialogue;
namespace CoffeeCoffee.Item
{

    public class MilkPitcher : MonoBehaviour
    {
        public GameObject pitcherSteam;
        const string STEAMING_PITCHER = "SteamPitcher";
        const string FINISHED_STEAMING_PITCHER = "FinishedSteaming";
        const string FILL_PITCHER = "FillPitcher";
        enum MilkType { none, nonFat, twoPercent, wholeMilk };
        OrderDictionary orderDictionary = new OrderDictionary();

        MilkType milkType;
        Animator animator;

        WaitForSeconds locationSwapTimer;
        WaitForSeconds animationWaitTimer;
        const string POUR_PITCHER_TRIGGER = "PourPitcher";
        const float LOCATION_TIMER = .2f;
        const float ANIMATION_TIMER = 1f;

        bool isNotSteamed = true;
        bool isFilled = false;
        float yOffset = 90.5f;
        float xOffset = -7f;

        float xPosition = 50f;
        float yPosition = 120f;
        float xOffsetReset = 100f;

        string CupInputMilk;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            milkType = MilkType.none;
            pitcherSteam.SetActive(false);
            locationSwapTimer = new WaitForSeconds(LOCATION_TIMER);
            animationWaitTimer = new WaitForSeconds(ANIMATION_TIMER);
        }
        public void BeginSteamingMilk()
        {
            animator.SetBool(STEAMING_PITCHER, true);
        }
        public void FinishedSteamingMilk()
        {
            animator.SetBool(STEAMING_PITCHER, false);
            animator.SetTrigger(FINISHED_STEAMING_PITCHER);
            pitcherSteam.gameObject.SetActive(true);
            pitcherSteam.transform.position = transform.position + new Vector3(xOffset, yOffset, 0);
            pitcherSteam.transform.SetParent(transform);
            isNotSteamed = false;
        }
        public void FillMilkPitcher()
        {
            animator.SetBool(FILL_PITCHER, true);
            isFilled = true;
        }

        private void SetMilkType(Collision2D other)
        {
            if (other.gameObject.GetComponent<MilkCarton>() && milkType == MilkType.none)
            {
                if (other.gameObject.GetComponent<MilkCarton>().milkCartonType == MilkCarton.MilkCartonType.nonFat)
                {
                    milkType = MilkType.nonFat;
                }
                else if (other.gameObject.GetComponent<MilkCarton>().milkCartonType == MilkCarton.MilkCartonType.twoPercent)
                {
                    milkType = MilkType.twoPercent;
                }
                else if (other.gameObject.GetComponent<MilkCarton>().milkCartonType == MilkCarton.MilkCartonType.wholeMilk)
                {
                    milkType = MilkType.wholeMilk;
                }
                Debug.Log("this milk is " + milkType, this);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            StopAllCoroutines();
            SetMilkType(other);
            if (other.gameObject.GetComponent<Cup>() && !isNotSteamed)
            {
                lockPosition(other);
            }
            
        }

        private void SetMilkTypeFromDictionary()
        {
            if (milkType == MilkType.nonFat)
            {
                CupInputMilk = orderDictionary.milks[1];
            }
            else if (milkType == MilkType.twoPercent)
            {
                CupInputMilk = orderDictionary.milks[0];
            }
            else if (milkType == MilkType.wholeMilk)
            {
                CupInputMilk = orderDictionary.milks[2];
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            
            if (other.gameObject.GetComponent<Cup>() && !isNotSteamed)
            {
                lockPosition(other);
                StartCoroutine(WaitForLocationSwap(other));
            }
            
        }
        

        private void lockPosition(Collision2D other)
        {
            transform.position = other.gameObject.transform.position + new Vector3(xPosition, yPosition, 0);
        }

        IEnumerator WaitForLocationSwap(Collision2D o)
        {
            yield return locationSwapTimer;
            SetMilkTypeFromDictionary();
            StartMilkPour();
            StartCoroutine(WaitForAnimation(o));
        }
        IEnumerator WaitForAnimation(Collision2D o)
        {
            yield return animationWaitTimer;
            FillCup(o);
            yield return locationSwapTimer;
            FinishMilkPour(o);
            yield return locationSwapTimer;
            gameObject.SetActive(false);
        }

        void FillCup(Collision2D cup)
        {
            cup.gameObject.GetComponent<Cup>().FillCupMilk(CupInputMilk);
        }

        private void FinishMilkPour(Collision2D o)
        {
            //respawn to the right of pitcher
            pitcherSteam.SetActive(false);
            transform.position = o.transform.position + new Vector3(xOffsetReset, 0, 0);
            gameObject.GetComponent<Collider2D>().enabled = true;
            gameObject.SetActive(false);
        }

        private void StartMilkPour()
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            animator.SetTrigger(POUR_PITCHER_TRIGGER);
        }
        public bool IsNotStreamed()
        {
            return isNotSteamed;
        }

        public bool IsFilled()
        {
            return isFilled;
        }
    }
}
