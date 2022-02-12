using System.Collections;
using System.Collections.Generic;
using CoffeeCoffee.Functionality;
using CoffeeCoffee.Item;
using UnityEngine;
namespace CoffeeCoffee.Triggers
{

    [RequireComponent(typeof(Triggerable))]
    public class MilkPitcherTrigger : MonoBehaviour
    {
        const float TIMER = 1f;
        Triggerable triggerable;
        WaitForSeconds occupiedTimer;

        bool hasMilkPitcher;

        private void Awake()
        {
            triggerable = GetComponent<Triggerable>();
            occupiedTimer = new WaitForSeconds(TIMER);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (triggerable.GetIsOccupied()) { return; }
            if (other.GetComponent<DragAndDrop>())
            {
                StartCoroutine(SetOccupiedTimer());
            }
            if (other.gameObject.GetComponent<MilkPitcher>())
            {
                hasMilkPitcher = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<MilkPitcher>())
            {
                hasMilkPitcher = false;
            }
        }
        IEnumerator SetOccupiedTimer()
        {
            yield return occupiedTimer;
            triggerable.SetIsOccupied(true);
        }

        public void NoLongerOccupied()
        {
            triggerable.ResetIsOccupied();
        }

        public void ResetMilkPitcherTrigger()
        {
            hasMilkPitcher = false;
        }

        public bool HasMilkPitcher()
        {
            return hasMilkPitcher;
        }

        public void ResetMilkPitcher()
        {
            hasMilkPitcher = false;
        }
    }
}
