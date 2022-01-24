using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Item;

public class SpawnCurrentCup : MonoBehaviour
{

    private void Start()
    {
        var tempCup = FindObjectOfType<Cup>();
        tempCup.transform.position = transform.position;
    }
}
