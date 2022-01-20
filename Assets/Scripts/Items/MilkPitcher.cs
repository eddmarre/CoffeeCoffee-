using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoffeeCoffee.Item
{

    public class MilkPitcher : MonoBehaviour
    {
        public GameObject pitcherSteam;
        const string STEAMING_PITCHER = "SteamPitcher";
        const string FINISHED_STEAMING_PITCHER = "FinishedSteaming";
        const string FILL_PITCHER = "FillPitcher";
        enum MilkType { none, nonFat, twoPercent, wholeMilk };

        MilkType milkType;
        Animator animator;

        bool isNotSteamed = true;
        bool isFilled = false;
        float yOffset = 90.5f;
        float xOffset = -7f;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            milkType = MilkType.none;
            pitcherSteam.SetActive(false);
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

        private void OnCollisionEnter2D(Collision2D other)
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
