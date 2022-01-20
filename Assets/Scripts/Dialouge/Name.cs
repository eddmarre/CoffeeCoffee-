using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CoffeeCoffee.Person;
using TMPro;
namespace CoffeeCoffee.Dialogue
{
    public class Name : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<TextMeshProUGUI>().text=GetComponentInParent<People>().gameObject.name;
        }
    }
}
