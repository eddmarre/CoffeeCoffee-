using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Item;
namespace CoffeeCoffee.Functionality
{
    public class CupManager : MonoBehaviour
    {
        [SerializeField] CupOrderManagerScriptableObject cupOrderManager;
        Cup thisCup;
        DragAndDrop dnd;
        new Rigidbody2D rigidbody2D;
        private void Awake()
        {
            thisCup = GetComponentInChildren<Cup>();
            dnd = GetComponentInChildren<DragAndDrop>();
            rigidbody2D = GetComponentInChildren<Rigidbody2D>();
        }
        private void Start()
        {
            Destroy(dnd);
            rigidbody2D.freezeRotation = true;
            thisCup.CupOrder = cupOrderManager.FinalCupOrder;
        }
    }
}
