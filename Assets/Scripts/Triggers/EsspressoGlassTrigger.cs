using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Functionality;
[RequireComponent(typeof(Triggerable))]
public class EsspressoGlassTrigger : MonoBehaviour
{
    bool isEsspressoGlass;
    DragAndDrop returnableDnd;
    EsspressoGlass returnableESPGlass;
    Triggerable triggerable;
    WaitForSeconds occupiedTimer;
    const float TIMER=1f;

    private void Awake()
    {
        triggerable = GetComponent<Triggerable>();
        occupiedTimer=new WaitForSeconds(TIMER);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StopAllCoroutines();
        if(triggerable.GetIsOccupied()){return;}
        if (other.GetComponent<DragAndDrop>())
        {
            SetDragAndDrop(other.GetComponent<DragAndDrop>());
            StartCoroutine(SetOccupiedTimer());
        }
        if (other.gameObject.GetComponent<EsspressoGlass>())
        {
            SetEsspressoGlass(other.GetComponent<EsspressoGlass>());
            isEsspressoGlass = true;
            StartCoroutine(SetOccupiedTimer());
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
    public bool IsEsspressoGlass()
    {
        return isEsspressoGlass;
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

    void SetDragAndDrop(DragAndDrop dnd)
    {
        returnableDnd = dnd;
    }

    public EsspressoGlass GetEsspressoGlass()
    {
        if (null == returnableESPGlass) { Debug.Log("NullCollider", this); }
        return returnableESPGlass;
    }
    void SetEsspressoGlass(EsspressoGlass espG)
    {
        returnableESPGlass = espG;
    }
}
