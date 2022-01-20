using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoffeeCoffee.Buttons
{


    public class TemperatureButton : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Debug.Log("temperatureButtonPressed", this);
        }
    }
}
