using System;
using System.Collections;
using System.Collections.Generic;
using CoffeeCoffee.Functionality;
using UnityEngine;
using CoffeeCoffee.Dialogue;

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

        public string CupInputEsspresso;
        public string CupInputShots;

        const string FILL_GLASS_TRIGGER = "FillGlass";
        const string POUR_GLASS_TRIGGER = "PourGlass";
        const float LOCATION_TIMER = .2f;
        const float ANIMATION_TIMER = 1f;

        OrderDictionary orderDictionary = new OrderDictionary();
        SpriteRenderer spriteRenderer;
        Animator animator;
        WaitForSeconds locationSwapTimer;
        WaitForSeconds animationWaitTimer;
        Transform originalParent;

        bool isEmpty = true;
        int empty = 0, full = 1;
        float xPosition = 50f;
        float yPosition = 120f;
        float xOffset = 100f;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            esspresso = Esspresso.none;
            esspressoSize = EsspressoSize.none;

            originalParent = transform.parent;

            locationSwapTimer = new WaitForSeconds(LOCATION_TIMER);
            animationWaitTimer = new WaitForSeconds(ANIMATION_TIMER);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            StopAllCoroutines();
            if (other.gameObject.GetComponent<Cup>() && !isEmpty)
            {
                lockPosition(other);
            }
        }
        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<Cup>() && !isEmpty)
            {
                lockPosition(other);
                StartCoroutine(WaitForLocationSwap(other));
            }
        }

        private void lockPosition(Collision2D other)
        {
            transform.position = other.gameObject.transform.position + new Vector3(xPosition, yPosition, 0);
        }

        IEnumerator WaitForLocationSwap(Collision2D o)
        {
            yield return locationSwapTimer;
            StartEsspressoPour();
            StartCoroutine(WaitForAnimation(o));
        }
        private void StartEsspressoPour()
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            animator.SetTrigger(POUR_GLASS_TRIGGER);
        }
        IEnumerator WaitForAnimation(Collision2D o)
        {
            yield return animationWaitTimer;
            FillCup(o);
            yield return locationSwapTimer;
            FinishEsspressoPour(o);
            yield return locationSwapTimer;
            gameObject.SetActive(false);
        }

        void FillCup(Collision2D cup)
        {
            try
            {
                cup.gameObject.GetComponent<Cup>().FillCupEsspresso(CupInputEsspresso, CupInputShots);
            }
            catch
            {
                Debug.LogWarning("Couldn't fill esspresso into cup", this);
            }
        }
        private void FinishEsspressoPour(Collision2D o)
        {
            //respawn to the right of pitcher
            transform.position = o.transform.position + new Vector3(xOffset, 0, 0);
            gameObject.GetComponent<Collider2D>().enabled = true;
        }

        public void PourEsspressoIntoShotGlass()
        {
            animator.SetTrigger(FILL_GLASS_TRIGGER);
            isEmpty = false;
            SetDictionaryEsspressoType();
            SetDictionaryEsspressoShots();
            setSprite();
        }
        private void SetDictionaryEsspressoShots()
        {
            if (esspressoSize == EsspressoSize.esingle)
            {
                CupInputShots = orderDictionary.shots[0];
            }
            else if (esspressoSize == EsspressoSize.edouble)
            {
                CupInputShots = orderDictionary.shots[1];
            }
        }

        private void SetDictionaryEsspressoType()
        {
            if (esspresso == Esspresso.blonde)
            {
                CupInputEsspresso = orderDictionary.esspressos[1];
            }
            else if (esspresso == Esspresso.regular)
            {
                CupInputEsspresso = orderDictionary.esspressos[0];
            }
            else if (esspresso == Esspresso.decaf)
            {
                CupInputEsspresso = orderDictionary.esspressos[2];
            }
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

        public bool IsEmpty()
        {
            return isEmpty;
        }
    }
}
