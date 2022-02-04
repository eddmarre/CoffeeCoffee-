using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Functionality;
using CoffeeCoffee.Item;
using CoffeeCoffee.EspressoMahchineButtons;

namespace CoffeeCoffee.Triggers
{
    [RequireComponent(typeof(Triggerable))]
    public class EsspressoGlassTrigger : MonoBehaviour
    {
        const float TIMER = 1f;

        DragAndDrop returnableDnd;
        EsspressoGlass returnableESPGlass;
        Triggerable triggerable;
        WaitForSeconds occupiedTimer;
        ExtractEspressoButton pullButton;

        bool isEsspressoGlass;

        private void Awake()
        {
            triggerable = GetComponent<Triggerable>();
            occupiedTimer = new WaitForSeconds(TIMER);

            pullButton=FindObjectOfType<ExtractEspressoButton>();
        }
        private void Start()
        {
            pullButton.gameObject.SetActive(false);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            StopAllCoroutines();
            StartCoroutine(PullButtonDelay());
            if (triggerable.GetIsOccupied()) { return; }
            if (other.GetComponent<DragAndDrop>())
            {
                SetDragAndDrop(other.GetComponent<DragAndDrop>());
                other.GetComponent<DragAndDrop>().StopDragMovement();
                StartCoroutine(SetOccupiedTimer());
            }
            if (other.gameObject.GetComponent<EsspressoGlass>())
            {
                SetEsspressoGlass(other.GetComponent<EsspressoGlass>());
                isEsspressoGlass = true;
            }
        }
        //Delay is necessary to allow time for enable/disable Collider2d
        IEnumerator PullButtonDelay()
        {
            yield return occupiedTimer;
            pullButton.gameObject.SetActive(true);
        }
        void SetDragAndDrop(DragAndDrop dnd)
        {
            returnableDnd = dnd;
        }

        IEnumerator SetOccupiedTimer()
        {
            yield return occupiedTimer;
            triggerable.SetIsOccupied(true);
        }

        void SetEsspressoGlass(EsspressoGlass espG)
        {
            returnableESPGlass = espG;
        }

        public void NoLongerOccupied()
        {
            triggerable.ResetIsOccupied();
        }
        public void ResetEsspressoGlassTrigger()
        {
            isEsspressoGlass = false;
        }

        public DragAndDrop GetDragAndDrop()
        {
            if (null == returnableDnd) { Debug.Log("NullCollider", this); }
            return returnableDnd;
        }
        public EsspressoGlass GetEsspressoGlass()
        {
            if (null == returnableESPGlass) { Debug.Log("NullCollider", this); }
            return returnableESPGlass;
        }

        public bool IsEsspressoGlass()
        {
            return isEsspressoGlass;
        }

    }
}
