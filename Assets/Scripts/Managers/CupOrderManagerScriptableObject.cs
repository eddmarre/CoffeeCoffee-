using System;
using System.Collections;
using System.Collections.Generic;
using CoffeeCoffee.Dialogue;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "CupOrderManagerScriptableObject", menuName = "ScriptableObjects/Cup Order Manager")]
public class CupOrderManagerScriptableObject : ScriptableObject
{
    public Order customerOrder;
    public Order playerInputedOrder;
    public Order FinalCupOrder;

    public UnityEvent<CupOrderManagerScriptableObject> customerOrderCreatedAction;
    public UnityEvent<CupOrderManagerScriptableObject> playerInputedOrderCreatedAction;
    public UnityEvent<CupOrderManagerScriptableObject> finalCupOrderCreatedAction;

    private void OnEnable()
    {
        if (customerOrderCreatedAction == null)
        {
            customerOrderCreatedAction = new UnityEvent<CupOrderManagerScriptableObject>();
        }
        if (playerInputedOrderCreatedAction == null)
        {
            playerInputedOrderCreatedAction = new UnityEvent<CupOrderManagerScriptableObject>();
        }
        if (finalCupOrderCreatedAction == null)
        {
            finalCupOrderCreatedAction = new UnityEvent<CupOrderManagerScriptableObject>();
        }
    }

    public void SetCustomerOrder()
    {
        customerOrderCreatedAction.Invoke(this);
    }

    public void SetPlayerInputedOrder()
    {
        playerInputedOrderCreatedAction.Invoke(this);
    }
    public void SetFinalCupOrder()
    {
        finalCupOrderCreatedAction.Invoke(this);
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

    public void ResetOrder()
    {
        customerOrder=null;
        playerInputedOrder=null;
        FinalCupOrder=null;
    }
}
