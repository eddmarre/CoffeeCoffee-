using System.Collections;
using CoffeeCoffee.Item;
using CoffeeCoffee.Triggers;
using UnityEngine;
namespace CoffeeCoffee.EspressoMahchineButtons
{
    public class LeverControls : MonoBehaviour
    {

        public GameObject animatedLever;
        const float WRONG_ITEM_SECONDS_TO_WAIT = .1f;
        const float PITCHER_RESTART_SECONDS_TO_WAIT = 2f;
        const float DELAYED_LEVER_UP_TIMER = .5f;
        const float TIME = .1f;
        const float RIGHT = 5f;
        const float LEFT = -5f;

        MilkPitcherTrigger milkPitcherTrigger;
        MilkPitcher milkPitcher;
        WaitForSeconds LeverTimer;
        WaitForSeconds pitcherRestartWaitTimer;
        WaitForSeconds wrongItemWaitTimer;
        WaitForSeconds delayedLeverTimer;

        float increaseBy = 10f;
        float decreaseBy = -10f;
        bool isPulled = false;
        bool isNotSpamming = true;
        
        private void Awake()
        {
            milkPitcherTrigger = FindObjectOfType<MilkPitcherTrigger>();

            LeverTimer = new WaitForSeconds(TIME);
            pitcherRestartWaitTimer = new WaitForSeconds(PITCHER_RESTART_SECONDS_TO_WAIT);
            wrongItemWaitTimer = new WaitForSeconds(WRONG_ITEM_SECONDS_TO_WAIT);
            delayedLeverTimer = new WaitForSeconds(DELAYED_LEVER_UP_TIMER);
        }
        private void OnMouseDown()
        {
            if (isNotSpamming)
            {
                StopAllCoroutines();
                isNotSpamming = false;
                StartCoroutine(ResetIsNotSpammingCheck());
                var pullLeverUpOrDown = isPulled ? StartCoroutine(PullLeverUP()) : StartCoroutine(PullLeverDown());
                if (milkPitcherTrigger.IsMilkPitcher())
                {
                    milkPitcher = milkPitcherTrigger.GetMilkPitcher();
                    if (milkPitcher.IsNotStreamed() && milkPitcher.IsFilled())
                    {
                        if (isPulled)
                        {
                            SteamMilk();
                        }
                        else
                        {
                            FinishSteaming();
                            AllowForReplacableItems();
                        }
                    }
                    else
                    {
                        StartCoroutine(DelayedLeverUp());
                        UnacceptedItemFunctionality();
                    }

                }
                else
                {
                    try
                    {
                        StartCoroutine(DelayedLeverUp());
                        UnacceptedItemFunctionality();
                    }
                    catch
                    {
                        Debug.Log("No Objects in Trigger", this);
                    }
                }
            }

        }

        IEnumerator ResetIsNotSpammingCheck()
        {
            yield return new WaitForSeconds(1f);
            isNotSpamming = true;
        }


        IEnumerator DelayedLeverUp()
        {
            yield return delayedLeverTimer;
            StartCoroutine(PullLeverUP());
        }

        private void FinishSteaming()
        {
            milkPitcher.FinishedSteamingMilk();
            milkPitcherTrigger.ResetMilkPitcherTrigger();
        }

        private void SteamMilk()
        {
            milkPitcher.BeginSteamingMilk();
        }
        private void UnacceptedItemFunctionality()
        {
            Transform objectTransform = milkPitcherTrigger.GetDragAndDrop().gameObject.transform;
            Vector2 originalPosition = objectTransform.position;
            StartCoroutine(WrongItemAnimation(objectTransform));
            ResetOriginalTransform(objectTransform, originalPosition);
            AllowForReplacableItems();
        }
        IEnumerator WrongItemAnimation(Transform t)
        {
            t.Translate(new Vector3(RIGHT, 0, 0));
            yield return wrongItemWaitTimer;
            t.Translate(new Vector3(LEFT, 0, 0));
            t.Translate(new Vector3(LEFT, 0, 0));
            yield return wrongItemWaitTimer;
            t.Translate(new Vector3(RIGHT, 0, 0));
            t.Translate(new Vector3(RIGHT, 0, 0));
            yield return wrongItemWaitTimer;
            t.Translate(new Vector3(LEFT, 0, 0));
            t.Translate(new Vector3(LEFT, 0, 0));
        }
        private static void ResetOriginalTransform(Transform objectTransform, Vector2 originalPosition)
        {
            objectTransform.position = originalPosition;
        }
        private void AllowForReplacableItems()
        {
            milkPitcherTrigger.gameObject.SetActive(false);
            milkPitcherTrigger.GetDragAndDrop().EnableClick();
            StartCoroutine(RestartPitcherTriggerTimer());
            milkPitcherTrigger.NoLongerOccupied();
        }

        IEnumerator RestartPitcherTriggerTimer()
        {
            yield return pitcherRestartWaitTimer;
            milkPitcherTrigger.gameObject.SetActive(true);
        }
        IEnumerator PullLeverDown()
        {
            isPulled = true;
            animatedLever.transform.Rotate(new Vector3(0, 0, decreaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, decreaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, decreaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, decreaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, decreaseBy));
            yield return LeverTimer;
        }
        IEnumerator PullLeverUP()
        {
            isPulled = false;
            animatedLever.transform.Rotate(new Vector3(0, 0, increaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, increaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, increaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, increaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, increaseBy));
            yield return LeverTimer;
        }
    }
}