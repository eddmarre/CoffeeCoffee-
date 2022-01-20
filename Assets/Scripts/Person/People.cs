using System.Collections;
using System.Collections.Generic;
using CoffeeCoffee.Dialogue;
using UnityEngine;
namespace CoffeeCoffee.Person
{
    public class People : MonoBehaviour
    {
        const float CLOSE_TEXT_BOX_TIMER = 8f;
        [SerializeField] string greeting = "Hello there, I would like a";

        OrderDialouge orderDialouge;
        GameManager gameManager;
        WaitForSeconds closeTextDelay;
        GameObject textBox;

        bool hasOrdered = false;
        private void Awake()
        {
            gameManager = GameManager.Instance;
            closeTextDelay = new WaitForSeconds(CLOSE_TEXT_BOX_TIMER);
            orderDialouge = new OrderDialouge();
            textBox = GetComponentInChildren<Canvas>().gameObject;
            textBox.SetActive(false);
        }
        private void OnMouseDown()
        {
            if (hasOrdered || gameManager.order != null) { return; }
            textBox.SetActive(true);
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
            int beverageIndex = Random.Range(0, 3);
            int temperaturIndex = Random.Range(0, 2);
            int shotIndex = Random.Range(0, 3);

            string order = orderDialouge.CreateDialougeOrder(greeting, sizeIndex, shotIndex, flavorIndex, milkIndex, esspressoIndex, beverageIndex, temperaturIndex);
            gameManager.order = orderDialouge.FindOrder();
            return order;
        }

    }
}
