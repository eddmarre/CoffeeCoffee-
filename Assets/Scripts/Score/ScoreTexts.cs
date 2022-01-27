using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace CoffeeCoffee.Score
{
    public class ScoreTexts : MonoBehaviour
    {
        TextMeshProUGUI text;
        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
        }

        public void SetText(string insertText)
        {
            text.text=insertText;
        }
    }
}
