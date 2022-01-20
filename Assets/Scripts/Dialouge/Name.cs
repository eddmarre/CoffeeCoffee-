using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CoffeeCoffee.Person;
namespace CoffeeCoffee.Dialogue
{
    public class Name : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<Text>().text=GetComponentInParent<People>().gameObject.name;
        }
    }
}
