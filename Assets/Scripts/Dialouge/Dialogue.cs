using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CoffeeCoffee.Person;
using TMPro;
namespace CoffeeCoffee.Dialogue
{
    public class Dialogue : MonoBehaviour
    {
        const float SENTENCE_TYPING_TIMER = .04f;
        TextMeshProUGUI dialougeText;
        People person;
        WaitForSeconds typingDelay;
        string personOrder;

        private void Awake()
        {
            typingDelay = new WaitForSeconds(SENTENCE_TYPING_TIMER);
            dialougeText = GetComponent<TextMeshProUGUI>();
            person = FindObjectOfType<People>();
        }

        public void CreateOrderDialouge()
        {
            personOrder = person.GetOrder();
            StartCoroutine(TypeSentence(personOrder));
        }

        IEnumerator TypeSentence(string d)
        {
            dialougeText.text = "";
            foreach (char letter in d.ToCharArray())
            {
                dialougeText.text += letter;
                yield return typingDelay;
            }
        }

    }
}
