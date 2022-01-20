using System;
using System.Collections;
using System.Collections.Generic;
using CoffeeCoffee.Functionality;
using UnityEngine;
namespace CoffeeCoffee.Item
{
    [RequireComponent(typeof(DragAndDrop))]
    public class EsspressoGlass : MonoBehaviour
    {
        public enum Esspresso { none, blonde, regular, decaf };
        public enum EsspressoSize { none, esingle, edouble };
        public Esspresso esspresso { get; set; }
        public EsspressoSize esspressoSize { get; set; }
        public Sprite[] sprites;
        const string FILL_GLASS_TRIGGER = "FillGlass";

        SpriteRenderer spriteRenderer;
        Animator animator;

        bool isEmpty = true;
        int empty = 0, full = 1;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            esspresso = Esspresso.none;
            esspressoSize = EsspressoSize.none;
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        public void PourEsspressoIntoShotGlass()
        {
            animator.SetTrigger(FILL_GLASS_TRIGGER);
            isEmpty = false;
            setSprite();
        }

        public bool IsEmpty()
        {
            return isEmpty;
        }

        public void setSprite()
        {
            if (isEmpty)
            {
                spriteRenderer.sprite = sprites[empty];
            }
            else
            {
                spriteRenderer.sprite = sprites[full];
            }
        }

    }
}
