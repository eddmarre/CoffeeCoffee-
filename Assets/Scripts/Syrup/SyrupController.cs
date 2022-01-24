using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoffeeCoffee.Syrup
{
    public class SyrupController : MonoBehaviour
    {
        Syrup[] syrups;

        private void Awake()
        {
            syrups = GetComponentsInChildren<Syrup>();
        }
        private void Start()
        {
            foreach (Syrup syrup in syrups)
            {
                syrup.DisableSyrupCollider();
            }
        }
        private void Update()
        {
            DisableSyrupColliders();
        }

        public void EnableSyrupColliders()
        {
            foreach (Syrup syrup in syrups)
            {
                syrup.EnableSyrupCollider();
            }
        }

        public void DisableSyrupColliders()
        {
            foreach (Syrup syrup in syrups)
            {
                if (syrup.isUsed == true)
                {
                    foreach (Syrup bottle in GetComponentsInChildren<Syrup>())
                    {
                        bottle.DisableSyrupCollider();
                    }
                }
            }
        }
    }
}
