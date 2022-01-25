using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Functionality;
using CoffeeCoffee.Dialogue;
using UnityEngine.SceneManagement;

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
        bool hasEsspresso = false;
        bool hasMilk = false;
        bool hasAllComponent = false;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
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
            SetDictionaryCupSizes();
        }
        private void Update()
        {
            if(hasMilk && hasEsspresso)
            {
                hasAllComponent=true;
            }
            if (hasAllComponent)
            {
                int register = 2;
                SceneManager.LoadScene(register);
            }
        }

        private void SetDictionaryCupSizes()
        {
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

        public void FillCupEsspresso(string esspresso, string shots)
        {
            CupOrder.shot = shots;
            CupOrder.esspresso = esspresso;
            hasEsspresso = true;
            SetFinalCupOrder();

        }

        public void FillCupMilk(string milk)
        {
            CupOrder.milk = milk;
            hasMilk = true;
            SetFinalCupOrder();
        }

        public bool IsEmpty()
        {
            return isEmpty;
        }

        public void SetFinalCupOrder()
        {
            gameManager.FinalCupOrder = CupOrder.DeepCopy();
        }

    }
}
