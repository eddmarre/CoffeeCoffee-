using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Functionality;

public class EsspressoGlassTrigger : MonoBehaviour
{
    bool isEsspressoGlass;
    DragAndDrop returnableDnd;
    EsspressoGlass returnableESPGlass;
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<DragAndDrop>())
        {
            SetDragAndDrop(other.GetComponent<DragAndDrop>());
        }
        if (other.gameObject.GetComponent<EsspressoGlass>())
        {
            SetEsspressoGlass(other.GetComponent<EsspressoGlass>());
            isEsspressoGlass = true;
        }
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
