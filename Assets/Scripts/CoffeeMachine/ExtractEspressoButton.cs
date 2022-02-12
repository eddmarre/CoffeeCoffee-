using UnityEngine;
using System.Collections;
using CoffeeCoffee.Triggers;
using CoffeeCoffee.Item;
using CoffeeCoffee.Functionality;

namespace CoffeeCoffee.EspressoMahchineButtons
{
    class ExtractEspressoButton : MonoBehaviour
    {

        [SerializeField] GameObject esspressoPourEffect;
        [SerializeField] Transform spawnLocation;

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
            glassRestartWaitTimer = new WaitForSeconds(GLASS_RESTART_SECONDS_TO_WAIT);
            wrongItemWaitTimer = new WaitForSeconds(WRONG_ITEM_SECONDS_TO_WAIT);

            esspressoGlassTrigger = FindObjectOfType<EsspressoGlassTrigger>();
            blondeButton = FindObjectOfType<BlondeSettingButton>();
            regularButton = FindObjectOfType<RegularSettingButton>();
            decafButton = FindObjectOfType<DecafSettingButton>();
            shotSetting = FindObjectOfType<EspressoShotSetting>();
        }
        private void OnMouseDown()
        {
            if (esspressoGlassTrigger.HasEsspressoGlass())
            {
                esspressoGlass = FindObjectOfType<EsspressoGlass>();
                if (esspressoGlass.IsEmpty())
                {
                    ChangeEsspressoSize();
                    ChangeEsspressoType();
                    PourEsspresso();
                    FindObjectOfType<EsspressoGlass>().EnableClick();
                    esspressoGlassTrigger.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                }
                else
                {
                    UnacceptedItemFunctionality();
                }
            }
        }

        private void ChangeEsspressoSize()
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
            Transform objectTransform = FindObjectOfType<EsspressoGlass>().transform;
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
            FindObjectOfType<EsspressoGlass>().EnableClick();
            StartCoroutine(RestartGlassTriggerTimer());
            esspressoGlassTrigger.NoLongerOccupied();
        }

        private void PourEsspresso()
        {
            esspressoGlass.PourEsspressoIntoShotGlass();
            CreatePouringEsspresso();
            esspressoGlassTrigger.ResetEsspressoGlassTrigger();
        }

        private void CreatePouringEsspresso()
        {
            var esspressoPour = Instantiate(esspressoPourEffect, spawnLocation.position, Quaternion.identity);
            float destroyTimer = 5f;
            Destroy(esspressoPour, destroyTimer);
        }

        IEnumerator RestartGlassTriggerTimer()
        {
            yield return glassRestartWaitTimer;
            try
            {
                esspressoGlassTrigger.gameObject.SetActive(true);
            }
            catch
            {
                Debug.Log("Glass Trigger Gone", this);
            }
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