using UnityEngine;
using CoffeeCoffee;
using CoffeeCoffee.Functionality;
using System.Collections;
using System.Collections.Generic;
using CofffeCoffee.Buttons;

namespace CoffeeCoffee.Buttons
{
    class ExtractEspressoButton : MonoBehaviour
    {
        EsspressoGlassTrigger esspressoGlassTrigger;
        EsspressoGlass esspressoGlass;
        WaitForSeconds glassRestartWaitTimer;
        WaitForSeconds wrongItemWaitTimer;
        const float GLASS_RESTART_SECONDS_TO_WAIT = 2f;
        const float WRONG_ITEM_SECONDS_TO_WAIT = .1f;
        const float RIGHT = 5f;
        const float LEFT = -5f;

        BlondeSettingButton blondeButton;
        RegularSettingButton regularButton;
        DecafSettingButton decafButton;
        EspressoShotSetting shotSetting;

        private void Awake()
        {
            esspressoGlassTrigger = FindObjectOfType<EsspressoGlassTrigger>();
            glassRestartWaitTimer = new WaitForSeconds(GLASS_RESTART_SECONDS_TO_WAIT);
            wrongItemWaitTimer = new WaitForSeconds(WRONG_ITEM_SECONDS_TO_WAIT);
            blondeButton = FindObjectOfType<BlondeSettingButton>();
            regularButton = FindObjectOfType<RegularSettingButton>();
            decafButton = FindObjectOfType<DecafSettingButton>();
            shotSetting = FindObjectOfType<EspressoShotSetting>();
        }
        private void OnMouseDown()
        {
            StopAllCoroutines();
            if (esspressoGlassTrigger.IsEsspressoGlass())
            {
                esspressoGlass = esspressoGlassTrigger.GetEsspressoGlass();
                if (esspressoGlass.IsEmpty())
                {
                    ChangeEsspressoSize();
                    ChangeEsspressoType();
                    Debug.Log(esspressoGlass.esspresso + " and is size " + esspressoGlass.esspressoSize, this);
                    PourEsspresso();
                    AllowForReplacableItems();
                }
                else
                {
                    UnacceptedItemFunctionality();
                }
            }
            else
            {
                try
                {
                    UnacceptedItemFunctionality();
                }
                catch
                {
                    Debug.Log("No Objects in Trigger", this);
                }

            }
        }

        void ChangeEsspressoSize()
        {
            if (shotSetting.GetIsDouble())
            {
                esspressoGlass.esspressoSize = EsspressoGlass.EsspressoSize.edouble;
            }
            else
            {
                esspressoGlass.esspressoSize = EsspressoGlass.EsspressoSize.esingle;
            }
        }

        private void ChangeEsspressoType()
        {
            if (decafButton.GetIsActive())
            {
                esspressoGlass.esspresso = EsspressoGlass.Esspresso.decaf;
            }
            else if (blondeButton.GetIsActive())
            {
                esspressoGlass.esspresso = EsspressoGlass.Esspresso.blonde;
            }
            else if (regularButton.GetIsActive())
            {
                esspressoGlass.esspresso = EsspressoGlass.Esspresso.regular;
            }
        }

        private void UnacceptedItemFunctionality()
        {
            Transform objectTransform = esspressoGlassTrigger.GetDragAndDrop().gameObject.transform;
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
            esspressoGlassTrigger.gameObject.SetActive(false);
            esspressoGlassTrigger.GetDragAndDrop().EnableClick();
            StartCoroutine(RestartGlassTriggerTimer());
            esspressoGlassTrigger.NoLongerOccupied();
        }

        private void PourEsspresso()
        {
            esspressoGlass.PourEsspressoIntoShotGlass();
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