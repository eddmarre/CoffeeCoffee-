using System.Collections;
using System.Collections.Generic;
using CoffeeCoffee.Functionality;
using CoffeeCoffee.Item;
using CoffeeCoffee.Syrup;
using UnityEngine;


namespace CoffeeCoffee.Triggers
{
    [RequireComponent(typeof(Triggerable))]
    public class SyrupTrigger : MonoBehaviour
    {
        public Syrup.Syrup syrup;
        DragAndDrop returnableDnd;
        Cup returnableCup;
        Triggerable triggerable;


        bool isCup;

        private void Awake()
        {
            triggerable = GetComponent<Triggerable>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            StopAllCoroutines();
            if (triggerable.GetIsOccupied()) { return; }
            if (other.GetComponent<DragAndDrop>())
            {
                SetDragAndDrop(other.GetComponent<DragAndDrop>());
            }
            if (other.gameObject.GetComponent<Cup>())
            {
                SetCup(other.GetComponent<Cup>());
                isCup = true;
                syrup.EnableSyrupCollider();
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            syrup.DisableSyrupCollider();
        }

        public void NoLongerOccupied()
        {
            triggerable.ResetIsOccupied();
        }
        public bool IsCup()
        {
            return isCup;
        }

        public void ResetCupTrigger()
        {
            isCup = false;
        }

        public DragAndDrop GetDragAndDrop()
        {
            if (null == returnableDnd) { Debug.Log("NullCollider", this); }
            return returnableDnd;
        }

        void SetDragAndDrop(DragAndDrop dnd)
        {
            returnableDnd = dnd;
        }

        public Cup GetCup()
        {
            if (null == returnableCup) { Debug.Log("NullCollider", this); }
            return returnableCup;
        }
        void SetCup(Cup cup)
        {
            returnableCup = cup;
        }
    }
}
