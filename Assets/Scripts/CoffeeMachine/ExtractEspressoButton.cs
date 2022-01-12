using UnityEngine;
using CoffeeCoffee;
using CoffeeCoffee.Functionality;
using System.Collections;
using System.Collections.Generic;

namespace CoffeeCoffee.Buttons
{
    class ExtractEspressoButton : MonoBehaviour
    {
        EsspressoGlassTrigger esspressoGlassTrigger;
        EsspressoGlass esspressoGlass;

        WaitForSeconds glassRestartWaitTimer;
        WaitForSeconds wrongItemWaitTimer;
        public const float GLASS_RESTART_SECONDS_TO_WAIT = 3f;
        public const float WRONG_ITEM_SECONDS_TO_WAIT = .1f;
        const float RIGHT = 5f;
        const float LEFT = -5f;

        private void Awake()
        {
            esspressoGlassTrigger = FindObjectOfType<EsspressoGlassTrigger>();
            glassRestartWaitTimer = new WaitForSeconds(GLASS_RESTART_SECONDS_TO_WAIT);
            wrongItemWaitTimer = new WaitForSeconds(WRONG_ITEM_SECONDS_TO_WAIT);
        }
        private void OnMouseDown()
        {
            StopAllCoroutines();
            if (esspressoGlassTrigger.IsEsspressoGlass())
            {
                PourEsspresso();
            }
            else
            {
                Transform objectTransform = esspressoGlassTrigger.GetDragAndDrop().gameObject.transform;
                Vector2 originalPosition = objectTransform.position;
                StartCoroutine(WrongItemAnimation(objectTransform));
                objectTransform.position = originalPosition;
                AllowForReplacableItems();
            }
        }

        private void AllowForReplacableItems()
        {
            esspressoGlassTrigger.gameObject.SetActive(false);
            esspressoGlassTrigger.GetDragAndDrop().EnableClick();
            StartCoroutine(RestartGlassTriggerTimer());
        }

        private void PourEsspresso()
        {
            esspressoGlass = esspressoGlassTrigger.GetEsspressoGlass();
            esspressoGlass.PourEsspressoIntoShotGlass();
            esspressoGlassTrigger.gameObject.SetActive(false);
            esspressoGlassTrigger.GetDragAndDrop().EnableClick();
            StartCoroutine(RestartGlassTriggerTimer());
            esspressoGlassTrigger.ResetEsspressoGlassTrigger();
        }

        IEnumerator RestartGlassTriggerTimer()
        {
            yield return glassRestartWaitTimer;
            esspressoGlassTrigger.gameObject.SetActive(true);
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