using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CoffeeCoffee.Score
{
    public class ScoreManager : MonoBehaviour
    {
        public ScoreTexts[] scoreTexts;
        int tip = 0, score = 1;

        private void Awake()
        {
            scoreTexts = GetComponentsInChildren<ScoreTexts>();
        }

        public void SetTipText(string insertText)
        {
            scoreTexts[tip].SetText(insertText);
        }
        public void SetScoreText(string insertText)
        {
            scoreTexts[score].SetText(insertText);
        }

    }
}