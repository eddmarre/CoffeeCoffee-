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
        public void SetName()
        {
            var name = FindObjectOfType<People>().gameObject.name;
            //name.Replace("(clone)", "").Trim();
            GetComponent<TextMeshProUGUI>().text =name;
        }
    }
}
