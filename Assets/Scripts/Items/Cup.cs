using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Functionality;
using CoffeeCoffee.Dialogue;

namespace CoffeeCoffee.Item
{
    [RequireComponent(typeof(DragAndDrop))]
    public class Cup : MonoBehaviour
    {


        public enum CupSize { small, medium, large };
        public CupSize cupSize { get; set; }
        GameManager gameManager;
        OrderDictionary orderDictionary = new OrderDictionary();
        public Order CupOrder;
        SpriteRenderer spriteRenderer;
        Animator animator;

        bool isEmpty = true;
        bool hasSyrup;
        bool hasEsspresso;
        bool hasMilk;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            gameManager = GameManager.Instance;
            if (gameManager.FinalCupOrder != null)
            {
                CupOrder = gameManager.FinalCupOrder.DeepCopy();
            }
            else
            {
                CupOrder = new Order();
            }

            if (cupSize == CupSize.small)
            {
                CupOrder.size = orderDictionary.sizes[0];
            }
            else if (cupSize == CupSize.medium)
            {
                CupOrder.size = orderDictionary.sizes[1];
            }
            else if (cupSize == CupSize.large)
            {
                CupOrder.size = orderDictionary.sizes[2];
            }
        }
        public void FillCup()
        {

        }

        public bool IsEmpty()
        {
            return isEmpty;
        }

        public void SetFinalCupOrder()
        {
            gameManager.FinalCupOrder = CupOrder.DeepCopy();
            gameManager.cupCopy = this;
        }

    }
}
