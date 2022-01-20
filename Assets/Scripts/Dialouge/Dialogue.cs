using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CoffeeCoffee.Person;
namespace CoffeeCoffee.Dialogue
{
    public class Dialogue : MonoBehaviour
    {
        const float SENTENCE_TYPING_TIMER = .05f;
        Text dialougeText;
        People person;
        WaitForSeconds typingDelay;

        private void Awake()
        {
            typingDelay = new WaitForSeconds(SENTENCE_TYPING_TIMER);
            person = GetComponentInParent<People>();
            dialougeText = GetComponent<Text>();
        }
        private void Start()
        {
            StartCoroutine(TypeSentence(person.GetOrder()));
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