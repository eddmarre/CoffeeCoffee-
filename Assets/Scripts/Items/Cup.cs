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
        public Order CupOrder;

        GameManager gameManager;
        OrderDictionary orderDictionary = new OrderDictionary();

        SpriteRenderer spriteRenderer;
        Animator animator;

        bool isEmpty = true;
        bool hasSyrup;
        bool hasEsspresso = false;
        bool hasMilk = false;
        bool hasAllComponent = false;
        bool canPerform;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            gameManager = GameManager.Instance;
            CreateCurrentCupOrder();
            SetDictionaryCupSizes();
            canPerform = true;
        }

        private void CreateCurrentCupOrder()
        {
            if (gameManager.FinalCupOrder != null)
            {
                CupOrder = gameManager.FinalCupOrder.DeepCopy();
            }
            else
            {
                CupOrder = new Order();
            }
        }

        private void Update()
        {

            canPerform = SetDictionaryLatte(canPerform);
            canPerform = SetDictionaryMachiatto(canPerform);
            ChangeSceneAfterCupFill();
        }

        private void ChangeSceneAfterCupFill()
        {
            if (hasMilk && hasEsspresso)
            {
                SetFinalCupOrder();
                hasAllComponent = true;
            }
            if (hasAllComponent)
            {
                int handOff = 5;
                SceneManager.LoadScene(handOff);
            }
        }

        private bool SetDictionaryMachiatto(bool canPerform)
        {
            if (hasMilk && !hasEsspresso && canPerform)
            {
                CupOrder.beverage = orderDictionary.beverages[1];
                canPerform = false;
            }

            return canPerform;
        }

        private bool SetDictionaryLatte(bool canPerform)
        {
            if (hasEsspresso && !hasMilk && canPerform)
            {
                CupOrder.beverage = orderDictionary.beverages[0];
                canPerform = false;
            }

            return canPerform;
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

        public void FillCupTemperature(string temp)
        {
            CupOrder.temperature = temp;
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
