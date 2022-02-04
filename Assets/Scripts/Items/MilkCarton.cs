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
        new Rigidbody2D rigidbody2D;

        float xPosition = 50f;
        float yPosition = 120f;
        float xOffset = 100f;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            originalParent = transform.parent;
            locationSwapTimer = new WaitForSeconds(LOCATION_TIMER);
            animationWaitTimer = new WaitForSeconds(ANIMATION_TIMER);
        }

        /* private void OnCollisionEnter2D(Collision2D other)
         {
             StopAllCoroutines();
             if (other.gameObject.GetComponent<MilkPitcher>() && !other.gameObject.GetComponent<MilkPitcher>().IsFilled())
             {
                 lockPosition(other);
             }
         }*/
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
            //transform.position = other.gameObject.transform.position + new Vector3(xPosition, yPosition, 0);
            rigidbody2D.position = other.gameObject.transform.position + new Vector3(xPosition, yPosition, 0);
        }

        IEnumerator WaitForLocationSwap(Collision2D o)
        {
            yield return locationSwapTimer;
            StartMilkPour();
            StartCoroutine(WaitForAnimation(o));
        }
        private void StartMilkPour()
        {
            GetComponent<Collider2D>().enabled = false;
            rigidbody2D.freezeRotation=false;
            animator.SetBool(POUR_MILK_ANIMATION, true);
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
            var mPitcher = FindObjectOfType<MilkPitcher>();
            rigidbody2D.position = mPitcher.GetComponent<Rigidbody2D>().position + new Vector2(xOffset, 0);
            GetComponent<Collider2D>().enabled = true;
            rigidbody2D.freezeRotation = true;
        }
    }
}
