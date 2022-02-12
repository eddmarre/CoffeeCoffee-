using UnityEngine;
using CoffeeCoffee.Dialogue;
using CoffeeCoffee.Triggers;
using System.Collections;

namespace CoffeeCoffee.Item
{
    public class Cup : MonoBehaviour
    {
        CupBaseState currentState;
        public CupBaseState emptyCupState = new EmptyCupState();
        public CupBaseState hasSyrupState = new HasSyrupState();
        public CupBaseState latteState = new LatteState();
        public CupBaseState machiattoState = new MachiatoState();
        public CupBaseState completeCupState = new CompleteCupState();

        public enum CupSize { small, medium, large };
        public CupSize cupSize { get; set; }

        public Order CupOrder;
        [SerializeField] CupOrderManagerScriptableObject cupOrderManager;

        SpriteRenderer spriteRenderer;
        Animator animator;

        new Rigidbody2D rigidbody2D;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            rigidbody2D=GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            CreateCurrentCupOrder();
            SetDictionaryCupSizes();
            FindSyrupsInScene();

            currentState = emptyCupState;
        }
        private void CreateCurrentCupOrder()
        {
            /*if (gameManager.FinalCupOrder != null)
            {
                CupOrder = gameManager.FinalCupOrder.DeepCopy();
            }
            else
            {
                CupOrder = new Order();
            }
            */
            if (cupOrderManager.FinalCupOrder != null)
            {
                CupOrder = cupOrderManager.FinalCupOrder.DeepCopy();
            }
            else
            {
                CupOrder = new Order();
            }
        }
        private void SetDictionaryCupSizes()
        {
            OrderDictionary orderDictionary = new OrderDictionary();
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
        private void FindSyrupsInScene()
        {
            var syrupFlavors = FindObjectsOfType<Syrup.Syrup>();
            foreach (Syrup.Syrup syrup in syrupFlavors)
            {
                syrup.onSyrupPumpAction += FillCupSyrupFlavor;
            }
        }
        private void Update()
        {
            currentState.UpdateState(this);
        }
        public void FillCupEsspresso(string esspresso, string shots)
        {
            CupOrder.shot = shots;
            CupOrder.esspresso = esspresso;
            SetFinalCupOrder();

        }

        public void FillCupMilk(string milk)
        {
            CupOrder.milk = milk;
            SetFinalCupOrder();
        }

        public void FillCupTemperature(string temp)
        {
            CupOrder.temperature = temp;
            SetFinalCupOrder();
        }

        private void FillCupSyrupFlavor(string inputFlavor)
        {
            CupOrder.flavor = inputFlavor;
            SetFinalCupOrder();
        }

        public void SetFinalCupOrder()
        {
            //gameManager.FinalCupOrder = CupOrder.DeepCopy();
            cupOrderManager.finalCupOrderCreatedAction.AddListener(SetFinalCupOrderAction);
            cupOrderManager.SetFinalCupOrder();
        }
        void SetFinalCupOrderAction(CupOrderManagerScriptableObject manager)
        {
            manager.FinalCupOrder = CupOrder.DeepCopy();
        }

        public void SwitchState(CupBaseState state)
        {
            currentState = state;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!other.GetComponent<Triggerable>().GetIsOccupied())
            {
                LockPositionMilkPitcher(other);
                if (!gameObject.GetComponent<Cup>())
                {
                    StartCoroutine(DisableClickTimer());
                }
            }
        }
        private void LockPositionMilkPitcher(Collider2D other)
        {
            rigidbody2D.position = other.transform.position;
        }
        public void EnableClick()
        {
            GetComponent<Collider2D>().enabled = true;
            GetComponent<CoffeeCoffee.Functionality.DragAndDrop>().AllowDragMovement();
            rigidbody2D.gravityScale = 100;
        }
        private void DisableClick()
        {
            GetComponent<CoffeeCoffee.Functionality.DragAndDrop>().StopDragMovement();
            rigidbody2D.gravityScale = 0;
        }
        IEnumerator DisableClickTimer()
        {
            yield return new WaitForSeconds(.5f);
            DisableClick();
        }
    }
}
