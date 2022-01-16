using System.Collections;
using System.Collections.Generic;
using CoffeeCoffee.Functionality;
using UnityEngine;
[RequireComponent(typeof(DragAndDrop))]
public class EsspressoGlass : MonoBehaviour
{
    public enum Esspresso { none, blonde, regular, decaf };
    public enum EsspressoSize { none, esingle, edouble };
    Animator animator;
    const string FILL_GLASS_TRIGGER = "FillGlass";
    bool isEmpty = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        esspresso = Esspresso.none;
        esspressoSize = EsspressoSize.none;
    }
    public void PourEsspressoIntoShotGlass()
    {
        animator.SetTrigger(FILL_GLASS_TRIGGER);
        isEmpty = false;
    }

    public bool IsEmpty()
    {
        return isEmpty;
    }

    public Esspresso esspresso { get; set; }
    public EsspressoSize esspressoSize { get; set; }

}
