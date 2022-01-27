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
                syrup.EnableSyrupCollider();
            }
        }
        void SetDragAndDrop(DragAndDrop dnd)
        {
            returnableDnd = dnd;
        }
        
        void SetCup(Cup cup)
        {
            returnableCup = cup;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            syrup.DisableSyrupCollider();
        }
    }
}
