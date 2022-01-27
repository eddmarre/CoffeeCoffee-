using System.Collections;
using System.Collections.Generic;
using CoffeeCoffee.Dialogue;
using UnityEngine;
namespace CoffeeCoffee.Person
{
    public class People : MonoBehaviour
    {
        public bool canBeHelped { get; set; }
        public bool hasOrdered { get; set; }

        const float CLOSE_TEXT_BOX_TIMER = 8f;

        [SerializeField] string greeting = "Hello there, I would like a";

        OrderDialouge orderDialouge;
        GameManager gameManager;
        WaitForSeconds closeTextDelay;
        GameObject textBox;
        Dialogue.Dialogue dialogue;
        Color originalSpriteColor;

        private void Awake()
        {
            canBeHelped = true;
            hasOrdered = false;

            dialogue = GetComponentInChildren<Dialogue.Dialogue>();
            textBox = GetComponentInChildren<Canvas>().gameObject;

            closeTextDelay = new WaitForSeconds(CLOSE_TEXT_BOX_TIMER);
            orderDialouge = new OrderDialouge();
        }
        private void Start()
        {
            gameManager = GameManager.Instance;
            textBox.SetActive(false);
        }
        private void OnMouseDown()
        {
            if (hasOrdered || gameManager.customerOrder != null) { return; }
            textBox.SetActive(true);
            dialogue.CreateOrderDialouge();
            canBeHelped = false;
            StopAllCoroutines();
            StartCoroutine(CloseTextBoxTimer());
        }
        IEnumerator CloseTextBoxTimer()
        {
            yield return closeTextDelay;
            textBox.SetActive(false);
            hasOrdered = true;
        }

        public string GetOrder()
        {
            int sizeIndex = Random.Range(0, 3);
            int flavorIndex = Random.Range(0, 5);
            int milkIndex = Random.Range(0, 3);
            int esspressoIndex = Random.Range(0, 3);
            int beverageIndex = Random.Range(0, 2);
            int temperaturIndex = Random.Range(0, 3);
            int shotIndex = Random.Range(0, 2);

            string order = orderDialouge.CreateDialougeOrder(greeting, sizeIndex, shotIndex, flavorIndex, milkIndex, esspressoIndex, beverageIndex, temperaturIndex);
            gameManager.customerOrder = orderDialouge.FindOrder();
            return order;
        }

        public void ChangeSpriteInactive()
        {
            originalSpriteColor = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
}
