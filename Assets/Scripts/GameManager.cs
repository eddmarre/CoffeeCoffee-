using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Dialogue;
using CoffeeCoffee.Person;
using CoffeeCoffee.SceneController;
using CoffeeCoffee.Item;
using CoffeeCoffee.Score;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public Order customerOrder;
    public Order playerInputedOrder;
    public Order FinalCupOrder;
    public Cup cupCopy;
    public People[] peoples;

    private void Awake()
    {
        CreateInstance();
        peoples = FindObjectsOfType<People>();
    }
    private void CreateInstance()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        DeactivateNonActiveCustomersAfterOrder();
        ReviewPlayerMonitorInput();
        ReviewPlayerCup();
    }
    private void DeactivateNonActiveCustomersAfterOrder()
    {
        if (customerOrder != null)
        {
            Debug.Log(customerOrder.ToString() + " customer order", this);
            if (peoples != null)
            {
                foreach (People person in peoples)
                {
                    if (person.canBeHelped == true)
                    {
                        person.ChangeSpriteInactive();
                    }
                }
            }
        }
    }

    private void ReviewPlayerMonitorInput()
    {
        if (playerInputedOrder != null && customerOrder != null && customerOrder.Equals(playerInputedOrder))
        {
            if (FindObjectOfType<ScoreManager>())
            {
                ScoreManager score = FindObjectOfType<ScoreManager>();
                score.SetScoreText("999");
            }
            Debug.Log("they match woohoo", this);
        }
    }

    private void ReviewPlayerCup()
    {
        if (FinalCupOrder != null && customerOrder != null && customerOrder.Equals(FinalCupOrder))
        {
            //reward player
            if (FindObjectOfType<ScoreManager>())
            {
                ScoreManager score = FindObjectOfType<ScoreManager>();
                score.SetTipText("9.99");
            }
            Debug.Log("HEY THATS MY LATTE", this);
        }
    }

    public Order GetFinalCupOrder()
    {
        return FinalCupOrder;
    }
}

