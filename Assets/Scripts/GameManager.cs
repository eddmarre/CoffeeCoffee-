using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Dialogue;
using CoffeeCoffee.Person;
using CoffeeCoffee.SceneController;
using CoffeeCoffee.Item;

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
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        peoples = FindObjectsOfType<People>();
    }

    private void Update()
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

        if (playerInputedOrder != null && customerOrder != null && customerOrder.Equals(playerInputedOrder))
        {
            //reward player
            Debug.Log("they match woohoo", this);
        }

        if (FinalCupOrder != null)
        {
           // Debug.Log(FinalCupOrder.ToString());
        }
    }

    public Order GetFinalCupOrder()
    {
        return FinalCupOrder;
    }
}

