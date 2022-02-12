using System.Collections;
using CoffeeCoffee.Item;
using CoffeeCoffee.Triggers;
using UnityEngine;
namespace CoffeeCoffee.EspressoMahchineButtons
{
    public class LeverControls : MonoBehaviour
    {

        [SerializeField] GameObject animatedLever;
        [SerializeField] GameObject milkSteamParticleEffect;
        [SerializeField] Transform spawnLocation;

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

        GameObject milkParticles;

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
                SpamCheck();

                var pullLeverUpOrDown = isPulled ? StartCoroutine(PullLeverUP()) : StartCoroutine(PullLeverDown());

                CheckTriggerForMilkPitcher();
            }
        }

        private void SpamCheck()
        {
            isNotSpamming = false;
            StartCoroutine(ResetIsNotSpammingCheck());
        }

        private void CheckTriggerForMilkPitcher()
        {
            if (milkPitcherTrigger.HasMilkPitcher())
            {
                milkPitcher = FindObjectOfType<MilkPitcher>();
                SteamMilkBehavior();
            }
            else
            {
                StartCoroutine(DelayedLeverUp());
            }
        }

        private void SteamMilkBehavior()
        {
            if (milkPitcher.currentState == milkPitcher.hasMilkState || milkPitcher.currentState == milkPitcher.steamingMilkState)
            {
                BeginSteamingMilk();
            }
            else
            {
                CantSteamMilkBehavior();
            }
        }

        private void BeginSteamingMilk()
        {
            if (isPulled)
            {
                SteamMilk();
            }
            else
            {
                FinishSteaming();

                FindObjectOfType<MilkPitcher>().EnableClick();
                milkPitcherTrigger.gameObject.SetActive(false);
                
                StartCoroutine(DelayedLeverDisable());
            }
        }
           private void SteamMilk()
        {
            milkPitcher.BeginSteamingMilk();
            milkParticles = Instantiate(milkSteamParticleEffect, spawnLocation.position, Quaternion.identity);
        }
        private void FinishSteaming()
        {
            milkPitcher.FinishedSteamingMilk();
            float destroyTimer = .5f;
            Destroy(milkParticles, destroyTimer);
            milkPitcherTrigger.ResetMilkPitcherTrigger();
        }

        private void CantSteamMilkBehavior()
        {
            StartCoroutine(DelayedLeverUp());
            UnacceptedItemFunctionality();
        }
        private void UnacceptedItemFunctionality()
        {
            Transform objectTransform = FindObjectOfType<MilkPitcher>().transform;
            Vector2 originalPosition = objectTransform.position;
            StartCoroutine(WrongItemAnimation(objectTransform));
            ResetOriginalTransform(objectTransform, originalPosition);
            AllowForReplacableItems();
        }
        private static void ResetOriginalTransform(Transform objectTransform, Vector2 originalPosition)
        {
            objectTransform.position = originalPosition;
        }
        private void AllowForReplacableItems()
        {
            milkPitcherTrigger.gameObject.SetActive(false);
            FindObjectOfType<MilkPitcher>().EnableClick();
            StartCoroutine(RestartPitcherTriggerTimer());
            milkPitcherTrigger.NoLongerOccupied();
            milkPitcherTrigger.ResetMilkPitcher();
        }

        IEnumerator RestartPitcherTriggerTimer()
        {
            yield return pitcherRestartWaitTimer;
            try
            {
                milkPitcherTrigger.gameObject.SetActive(true);
            }
            catch
            {
                Debug.Log("no pitcher trigger", this);
            }
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
        IEnumerator DelayedLeverDisable()
        {
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);
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
    }
}