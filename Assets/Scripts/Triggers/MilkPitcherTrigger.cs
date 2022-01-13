using System.Collections;
using System.Collections.Generic;
using CoffeeCoffee.Functionality;
using UnityEngine;
[RequireComponent(typeof(Triggerable))]
public class MilkPitcherTrigger : MonoBehaviour
{
    bool isMilkPitcher;
    DragAndDrop returnableDnd;
    MilkPitcher returnableMLKPitcher;
    Triggerable triggerable;
    WaitForSeconds occupiedTimer;
    const float TIMER = 1f;

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
    IEnumerator SetOccupiedTimer()
    {
        yield return occupiedTimer;
        triggerable.SetIsOccupied(true);
    }
    public void NoLongerOccupied()
    {
        triggerable.ResetIsOccupied();
    }
    public bool IsMilkPitcher()
    {
        return isMilkPitcher;
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

    void SetDragAndDrop(DragAndDrop dnd)
    {
        returnableDnd = dnd;
    }

    public MilkPitcher GetMilkPitcher()
    {
        if (null == returnableMLKPitcher) { Debug.Log("NullCollider", this); }
        return returnableMLKPitcher;
    }
    void SetMilkPitcher(MilkPitcher mlkG)
    {
        returnableMLKPitcher = mlkG;
    }
}
