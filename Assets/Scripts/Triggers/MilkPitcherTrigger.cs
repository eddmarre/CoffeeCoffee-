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

        DragAndDrop returnableDnd;
        MilkPitcher returnableMLKPitcher;
        Triggerable triggerable;
        WaitForSeconds occupiedTimer;

        bool isMilkPitcher;

        private void Awake()
        {
            triggerable = GetComponent<Triggerable>();
            occupiedTimer = new WaitForSeconds(TIMER);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            StopAllCoroutines();
            if (triggerable.GetIsOccupied()) { return; }
            if (other.GetComponent<DragAndDrop>())
            {
                SetDragAndDrop(other.GetComponent<DragAndDrop>());
                StartCoroutine(SetOccupiedTimer());
            }
            if (other.gameObject.GetComponent<MilkPitcher>())
            {
                SetMilkPitcher(other.GetComponent<MilkPitcher>());
                isMilkPitcher = true;
            }
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
        void SetMilkPitcher(MilkPitcher mlkG)
        {
            returnableMLKPitcher = mlkG;
        }

        public void NoLongerOccupied()
        {
            triggerable.ResetIsOccupied();
        }

        public void ResetMilkPitcherTrigger()
        {
            isMilkPitcher = false;
        }

        public DragAndDrop GetDragAndDrop()
        {
            if (null == returnableDnd) { Debug.Log("NullCollider", this); }
            return returnableDnd;
        }
        public MilkPitcher GetMilkPitcher()
        {
            if (null == returnableMLKPitcher) { Debug.Log("NullCollider", this); }
            return returnableMLKPitcher;
        }
        public bool IsMilkPitcher()
        {
            return isMilkPitcher;
        }
    }
}
