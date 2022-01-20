using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Dialogue;
using CoffeeCoffee.Person;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public Order order;
    People[] peoples;

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

        
        peoples=FindObjectsOfType<People>();
        foreach (People person in peoples)
        {
           Debug.Log(person.gameObject.name,this);
        }
    }

    private void Update()
    {
        if(order!=null)
        {
            Debug.Log(order.ToString(),this);
        }
    }
}

