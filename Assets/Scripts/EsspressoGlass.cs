using System.Collections;
using System.Collections.Generic;
using CoffeeCoffee.Functionality;
using UnityEngine;
[RequireComponent(typeof(DragAndDrop))]
public class EsspressoGlass : MonoBehaviour
{
    Animator animator;
    const string FILL_GLASS_TRIGGER = "FillGlass";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void PourEsspressoIntoShotGlass()
    {
        animator.SetTrigger(FILL_GLASS_TRIGGER);
    }

}
