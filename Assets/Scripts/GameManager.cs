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

    private void Awake()
    {
        CreateInstance();
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

    public float ReviewPlayerMonitorInput()
    {
        float finalScore = createFinalScore();
        return finalScore;
    }

    private float createFinalScore()
    {
        float finalScore = 0;
        float increaseAmount = 100 / 7;
        if (playerInputedOrder.size == customerOrder.size)
        {
            finalScore += increaseAmount;
        }
        if (playerInputedOrder.flavor == customerOrder.flavor)
        {
            finalScore += increaseAmount;
        }
        if (playerInputedOrder.milk == customerOrder.milk)
        {
            finalScore += increaseAmount;
        }
        if (playerInputedOrder.esspresso == customerOrder.esspresso)
        {
            finalScore += increaseAmount;
        }
        if (playerInputedOrder.beverage == customerOrder.beverage)
        {
            finalScore += increaseAmount;
        }
        if (playerInputedOrder.temperature == customerOrder.temperature)
        {
            finalScore += increaseAmount;
        }
        if (playerInputedOrder.shot == customerOrder.shot)
        {
            finalScore += increaseAmount;
        }

        return finalScore;
    }

    public float ReviewPlayerCup()
    {

        float finalTipAmount = createTips();
        return finalTipAmount;

    }

    private float createTips()
    {
        float increasePrecentage = 0;
        float increaseAmount = 100 / 7;
        if (FinalCupOrder.size == customerOrder.size)
        {
            increasePrecentage += increaseAmount;
        }
        if (FinalCupOrder.flavor == customerOrder.flavor)
        {
            increasePrecentage += increaseAmount;
        }
        if (FinalCupOrder.milk == customerOrder.milk)
        {
            increasePrecentage += increaseAmount;
        }
        if (FinalCupOrder.esspresso == customerOrder.esspresso)
        {
            increasePrecentage += increaseAmount;
        }
        if (FinalCupOrder.beverage == customerOrder.beverage)
        {
            increasePrecentage += increaseAmount;
        }
        if (FinalCupOrder.temperature == customerOrder.temperature)
        {
            increasePrecentage += increaseAmount;
        }
        if (FinalCupOrder.shot == customerOrder.shot)
        {
            increasePrecentage += increaseAmount;
        }

        return increasePrecentage;
    }

    public Order GetFinalCupOrder()
    {
        return FinalCupOrder;
    }
}

