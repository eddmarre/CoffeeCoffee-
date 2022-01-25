using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Item;
namespace CoffeeCoffee.Functionality
{
    public class CupManager : MonoBehaviour
    {
        GameManager gameManager;
        Cup thisCup;
        private void Awake()
        {
            thisCup = GetComponentInChildren<Cup>();
        }
        private void Start()
        {
            gameManager = GameManager.Instance;
            thisCup.CupOrder = gameManager.GetFinalCupOrder();
        }

        private void Update()
        {
            try
            {
                Debug.Log(thisCup.CupOrder.ToString(), this);
            }
            catch
            {
                Debug.LogWarning("No final Cup Order in Game Manager", this);
            }

        }
    }
}
