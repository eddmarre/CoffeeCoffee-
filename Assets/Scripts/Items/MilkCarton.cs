using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoffeeCoffee.Item
{
    public class MilkCarton : MonoBehaviour
    {
        public enum MilkCartonType { none, nonFat, twoPercent, wholeMilk };
        public MilkCartonType milkCartonType;
        const string POUR_MILK_ANIMATION = "PourMilk";
        const float LOCATION_TIMER = .2f;
        const float ANIMATION_TIMER = 1f;

        Animator animator;
        Transform originalParent;
        WaitForSeconds locationSwapTimer;
        WaitForSeconds animationWaitTimer;

        float xPosition = 50f;
        float yPosition = 120f;
        float xOffset = 100f;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            originalParent = transform.parent;
            locationSwapTimer = new WaitForSeconds(LOCATION_TIMER);
            animationWaitTimer = new WaitForSeconds(ANIMATION_TIMER);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            StopAllCoroutines();
            if (other.gameObject.GetComponent<MilkPitcher>() && !other.gameObject.GetComponent<MilkPitcher>().IsFilled())
            {
                lockPosition(other);
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<MilkPitcher>() && !other.gameObject.GetComponent<MilkPitcher>().IsFilled())
            {
                lockPosition(other);
                transform.SetParent(other.gameObject.transform);
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
            StartMilkPour();
            StartCoroutine(WaitForAnimation(o));
        }
        IEnumerator WaitForAnimation(Collision2D o)
        {
            yield return animationWaitTimer;
            FillPitcher();
            yield return locationSwapTimer;
            FinishMilkPour(o);
        }

        private static void FillPitcher()
        {
            FindObjectOfType<MilkPitcher>().FillMilkPitcher();
        }

        private void FinishMilkPour(Collision2D o)
        {
            animator.SetBool(POUR_MILK_ANIMATION, false);
            o.gameObject.transform.DetachChildren();
            transform.SetParent(originalParent);
            //respawn to the right of pitcher
            transform.position = FindObjectOfType<MilkPitcher>().transform.position + new Vector3(xOffset, 0, 0);
            gameObject.GetComponent<Collider2D>().enabled = true;
        }

        private void StartMilkPour()
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            animator.SetBool(POUR_MILK_ANIMATION, true);
        }


    }
}
