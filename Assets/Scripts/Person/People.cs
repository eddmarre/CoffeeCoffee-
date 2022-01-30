using System.Collections;
using System.Collections.Generic;
using CoffeeCoffee.Dialogue;
using UnityEngine;
namespace CoffeeCoffee.Person
{
    public class People : MonoBehaviour
    {
        [Range(0, 2)] public int PersonBuildIndex;
        float personWalkSpeed = 2f;
        public bool canBeHelped { get; set; }

        const float CLOSE_TEXT_BOX_TIMER = 5f;
        const string REACHED_DESTINATION_TRIGGER = "ReachedDestination";

        [SerializeField] string greeting = "Hello there, I would like a";

        OrderDialouge orderDialouge;
        GameManager gameManager;
        WaitForSeconds closeTextDelay;
        GameObject textBox;
        Dialogue.Dialogue dialogue;
        Color originalSpriteColor;
        Transform moveTolocation;
        bool isFirstTimePlacingOrder;

        private void Awake()
        {
            canBeHelped = true;
            isFirstTimePlacingOrder = true;

            dialogue = FindObjectOfType<Dialogue.Dialogue>();
            textBox = FindObjectOfType<TextCanvas>().gameObject;

            moveTolocation = FindObjectOfType<MoveLocation>().transform;

            closeTextDelay = new WaitForSeconds(CLOSE_TEXT_BOX_TIMER);
            orderDialouge = new OrderDialouge();
        }
        private void Start()
        {
            gameManager = GameManager.Instance;

            textBox.SetActive(false);
            Vector2 location = new Vector2(moveTolocation.position.x, moveTolocation.position.y);

            StartCoroutine(LerpPosition(location, personWalkSpeed));
        }

        IEnumerator LerpPosition(Vector2 targetPosition, float duration)
        {
            float time = 0;
            Vector2 startPosition = transform.position;

            while (time < duration)
            {
                transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPosition;
        }
        private void OnMouseDown()
        {
            if (!canBeHelped && gameManager.customerOrder != null) { return; }
            textBox.SetActive(true);
            FindObjectOfType<Name>().SetName();
            if (isFirstTimePlacingOrder)
            {
                dialogue.CreateOrderDialouge();
                isFirstTimePlacingOrder = false;
                StartCoroutine(CloseTextBoxTimer());
            }
            else
            {
                StartCoroutine(CloseTextBoxTimerAgainForReOrdering());
            }

        }
        IEnumerator CloseTextBoxTimer()
        {
            canBeHelped = false;
            yield return closeTextDelay;
            textBox.SetActive(false);
            canBeHelped = true;
        }

        IEnumerator CloseTextBoxTimerAgainForReOrdering()
        {
            canBeHelped = false;
            yield return new WaitForSeconds(3f);
            textBox.SetActive(false);
            canBeHelped = true;
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
