using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkCarton : MonoBehaviour
{
    float xPosition = 50f;
    float yPosition = 120f;
    float xOffset = 100f;
    Animator animator;
    const string POUR_MILK_ANIMATION = "PourMilk";
    Transform originalParent;
    WaitForSeconds locationSwapTimer;
    WaitForSeconds animationWaitTimer;

    const float LOCATION_TIMER = .2f;
    const float ANIMATION_TIMER = 1f;

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
        if (other.gameObject.GetComponent<MilkPitcher>())
        {
            lockPosition(other);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<MilkPitcher>())
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
        FillPitcher(o);
        yield return locationSwapTimer;
        FinishMilkPour(o);
    }

    private static void FillPitcher(Collision2D o)
    {
        o.gameObject.GetComponent<MilkPitcher>().FillMilkPitcher();
    }

    private void FinishMilkPour(Collision2D o)
    {
        animator.SetBool(POUR_MILK_ANIMATION, false);
        o.gameObject.transform.DetachChildren();
        transform.SetParent(originalParent);
        //respawn to the right of pitcher
        transform.position = o.transform.position + new Vector3(xOffset, 0, 0);
        gameObject.GetComponent<Collider2D>().enabled = true;
    }

    private void StartMilkPour()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        animator.SetBool(POUR_MILK_ANIMATION, true);
    }


}
