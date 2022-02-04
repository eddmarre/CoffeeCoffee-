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
        GameManager gameManager;
        private void Awake()
        {
            scoreTexts = GetComponentsInChildren<ScoreTexts>();
        }

        private void Start()
        {
            gameManager = GameManager.Instance;
            try
            {
                SetTipText(gameManager.ReviewPlayerMonitorInput());
                SetScoreText(gameManager.ReviewPlayerCup());
            }
            catch
            {
                Debug.Log("No Order to set Scores", this);
            }
        }

        public void SetTipText(float FinalCupStatus)
        {
            string tipAmount = "";
            int randomTip;
            if (FinalCupStatus == 0f)
            {
                tipAmount = "0.00";
                scoreTexts[tip].SetText(tipAmount);
            }
            if (FinalCupStatus > 0f && FinalCupStatus < 15f)
            {
                randomTip = Random.Range(0, 16);
                tipAmount = "0." + randomTip.ToString();
                scoreTexts[tip].SetText(tipAmount);
            }
            else if (FinalCupStatus > 15f && FinalCupStatus < 29f)
            {
                randomTip = Random.Range(16, 30);
                tipAmount = "0." + randomTip.ToString();
                scoreTexts[tip].SetText(tipAmount);
            }
            else if (FinalCupStatus > 29f && FinalCupStatus < 43f)
            {
                randomTip = Random.Range(30, 44);
                tipAmount = "0." + randomTip.ToString();
                scoreTexts[tip].SetText(tipAmount);
            }
            else if (FinalCupStatus > 43f && FinalCupStatus < 58f)
            {
                randomTip = Random.Range(44, 59);
                tipAmount = "0." + randomTip.ToString();
                scoreTexts[tip].SetText(tipAmount);
            }
            else if (FinalCupStatus > 58f && FinalCupStatus < 72f)
            {
                randomTip = Random.Range(58, 73);
                tipAmount = "0." + randomTip.ToString();
                scoreTexts[tip].SetText(tipAmount);
            }
            else if (FinalCupStatus > 72f && FinalCupStatus < 86f)
            {
                randomTip = Random.Range(73, 87);
                tipAmount = "0." + randomTip.ToString();
                scoreTexts[tip].SetText(tipAmount);
            }
            else if (FinalCupStatus == 100f)
            {
                randomTip = Random.Range(0, 101);
                tipAmount = "1." + randomTip.ToString();
                scoreTexts[tip].SetText(tipAmount);
            }
        }
        public void SetScoreText(float PlayerOrderStatus)
        {
            string ScoreAmount = "";
            if (PlayerOrderStatus == 0f)
            {
                ScoreAmount = "0";
                scoreTexts[score].SetText(ScoreAmount);
            }
            if (PlayerOrderStatus > 0f && PlayerOrderStatus < 15f)
            {

                ScoreAmount = "15";
                scoreTexts[score].SetText(ScoreAmount);
            }
            else if (PlayerOrderStatus > 15f && PlayerOrderStatus < 29f)
            {

                ScoreAmount = "29";
                scoreTexts[score].SetText(ScoreAmount);
            }
            else if (PlayerOrderStatus > 29f && PlayerOrderStatus < 43f)
            {

                ScoreAmount = "43";
                scoreTexts[score].SetText(ScoreAmount);
            }
            else if (PlayerOrderStatus > 43f && PlayerOrderStatus < 58f)
            {
                ScoreAmount = "58";
                scoreTexts[score].SetText(ScoreAmount);
            }
            else if (PlayerOrderStatus > 58f && PlayerOrderStatus < 72f)
            {
                ScoreAmount = "72";
                scoreTexts[score].SetText(ScoreAmount);
            }
            else if (PlayerOrderStatus > 72f && PlayerOrderStatus < 86f)
            {
                ScoreAmount = "86";
                scoreTexts[score].SetText(ScoreAmount);
            }
            else if (PlayerOrderStatus == 100f)
            {
                ScoreAmount = "100";
                scoreTexts[score].SetText(ScoreAmount);
            }
        }

    }
}