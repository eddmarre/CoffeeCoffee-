using System;
using System.Collections.Generic;
using CoffeeCoffee.Functionality;
using UnityEngine;

namespace CoffeeCoffee.Item
{

    [RequireComponent(typeof(DragAndDrop))]
    public class EsspressoGlass : MonoBehaviour
    {
        public EsspressoGlassBaseState currentState;
        public EsspressoGlassBaseState emptyState = new EsspressoGlassEmptyState();
        public EsspressoGlassBaseState hasEsspressoState = new EsspressoGlassHasEsspressoState();
        public EsspressoGlassBaseState pourEsspressoState = new EsspressoGlassPourEsspressoState();
        public EsspressoGlassBaseState finishedEsspressoState = new EsspressoGlassFinishedEsspressoState();

        public CreateEsspresso esspressoData;
        public ICreateEsspresso createEsspresso;


        public new Rigidbody2D rigidbody2D;
        public Animator animator;
        [SerializeField] Sprite[] sprites;

        SpriteRenderer spriteRenderer;

        bool isEmpty = true;
        int empty = 0, full = 1;
        private void Awake()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            rigidbody2D = GetComponent<Rigidbody2D>();

            createEsspresso = GetComponent<ICreateEsspresso>();
            esspressoData=GetComponent<CreateEsspresso>();

            createEsspresso.initializeEsspresso();
        }

        private void Start()
        {
            currentState = emptyState;
            currentState.StartState(this);
        }
        private void Update()
        {
            currentState.UpdateState(this);
            Debug.Log($"{currentState}");
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            currentState.OnCollisionEnterState(this, other);
        }
        private void OnCollisionStay2D(Collision2D other)
        {
            currentState.OnCollisionStayState(this, other);
        }

        public void PourEsspressoIntoShotGlass()
        {
            const string FILL_GLASS_TRIGGER = "FillGlass";
            animator.SetTrigger(FILL_GLASS_TRIGGER);
            isEmpty = false;
            createEsspresso.SetDictionaryEsspressoType();
            createEsspresso.SetDictionaryEsspressoShots();
            setSprite();
        }
        private void setSprite()
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


        public void FillCup()
        {
            try
            {
                FindObjectOfType<Cup>().FillCupEsspresso(createEsspresso.CupInputEsspresso, createEsspresso.CupInputShots);
            }
            catch
            {
                Debug.LogWarning("Couldn't fill esspresso into cup", this);
            }
        }
        public void FinishEsspressoPour()
        {
            gameObject.SetActive(false);
        }

        public bool IsEmpty()
        {
            return isEmpty;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            currentState.OnTriggerStayState(this, other);

        }
        public void EnableClick()
        {
            GetComponent<Collider2D>().enabled = true;
            GetComponent<CoffeeCoffee.Functionality.DragAndDrop>().AllowDragMovement();
            rigidbody2D.gravityScale = 100;
        }
        public void DisableClick()
        {
            GetComponent<CoffeeCoffee.Functionality.DragAndDrop>().StopDragMovement();
            rigidbody2D.gravityScale = 0;
        }
        public void SwitchState(EsspressoGlassBaseState state)
        {
            currentState = state;
        }
    }
}
