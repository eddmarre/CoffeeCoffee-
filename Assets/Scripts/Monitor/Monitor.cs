using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoffeeCoffee.Monitor
{


    public class Monitor : MonoBehaviour
    {
        public GameObject FullScreenMonitor;

        private void Awake()
        {
            gameObject.SetActive(true);
            FullScreenMonitor.SetActive(false);
        }
        private void OnMouseDown()
        {
            gameObject.SetActive(false);
            FullScreenMonitor.SetActive(true);
        }

        public void CloseMonitor()
        {
            gameObject.SetActive(true);
            FullScreenMonitor.SetActive(false);
        }
    }
}
