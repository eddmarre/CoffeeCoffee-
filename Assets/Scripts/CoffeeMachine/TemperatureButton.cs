using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Dialogue;
namespace CoffeeCoffee.EspressoMahchineButtons
{
    public class TemperatureButton : MonoBehaviour
    {
        [SerializeField] GameObject[] tempSettings;
        const int regTemp = 0, warmTemp = 1, exHotTemp = 2;
        int clickCounter;
        OrderDictionary orderDictionary = new OrderDictionary();

        string CupInputTemperature;

        private void Start()
        {
            CupInputTemperature = orderDictionary.temperatures[0];
            clickCounter = 0;
            tempSettings[1].SetActive(false);
            tempSettings[2].SetActive(false);
        }
        private void OnMouseDown()
        {
            SetTemperature();
        }

        private void SetTemperature()
        {
            ++clickCounter;
            if (clickCounter == 0)
            {
                CupInputTemperature = orderDictionary.temperatures[0];
                tempSettings[0].SetActive(true);
                tempSettings[1].SetActive(false);
                tempSettings[2].SetActive(false);
            }
            else if (clickCounter == 1)
            {
                CupInputTemperature = orderDictionary.temperatures[1];

                tempSettings[0].SetActive(false);
                tempSettings[1].SetActive(true);
                tempSettings[2].SetActive(false);
            }
            else if (clickCounter == 2)
            {
                CupInputTemperature = orderDictionary.temperatures[2];
                clickCounter = -1;
                tempSettings[0].SetActive(false);
                tempSettings[1].SetActive(false);
                tempSettings[2].SetActive(true);
            }
        }

        public string GetTemperature()
        {
            return CupInputTemperature;
        }
    }
}
