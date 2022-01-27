using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Item;
using CoffeeCoffee.Dialogue;
using UnityEngine.SceneManagement;

namespace CoffeeCoffee.Syrup
{

    public class Syrup : MonoBehaviour
    {
        public enum SyrupFlavor { vanilla, caramel, hazelnut, classic, mocha };
        public SyrupFlavor syrupFlavor;
        public bool isUsed;

        const float LEVEL_CHANGE_DELAY = 1f;

        
        new Collider2D collider2D;
        OrderDictionary orderDictionary = new OrderDictionary();
        Cup cup;
        WaitForSeconds changeLevelWaitTimer;

        string CupInputFlavor;
        private void Awake()
        {
            collider2D = GetComponent<Collider2D>();
            isUsed = false;
            AssignFlavorTypeFromDictionary();
            changeLevelWaitTimer = new WaitForSeconds(LEVEL_CHANGE_DELAY);
        }

        private void AssignFlavorTypeFromDictionary()
        {
            if (syrupFlavor == SyrupFlavor.vanilla)
            {
                CupInputFlavor = orderDictionary.flavors[0];
            }
            else if (syrupFlavor == SyrupFlavor.caramel)
            {
                CupInputFlavor = orderDictionary.flavors[1];
            }
            else if (syrupFlavor == SyrupFlavor.hazelnut)
            {
                CupInputFlavor = orderDictionary.flavors[2];
            }
            else if (syrupFlavor == SyrupFlavor.classic)
            {
                CupInputFlavor = orderDictionary.flavors[3];
            }
            else if (syrupFlavor == SyrupFlavor.mocha)
            {
                CupInputFlavor = orderDictionary.flavors[4];
            }
        }

        private void OnMouseDown()
        {
            isUsed = true;
            AddSyrupInCup();
            ChangeToEsspressoMachineScene();
        }

        private void AddSyrupInCup()
        {
            cup = FindObjectOfType<Cup>();
            cup.CupOrder.flavor = CupInputFlavor;
            cup.SetFinalCupOrder();
        }
        public void ChangeToEsspressoMachineScene()
        {
            int espMachine = 3;
            StartCoroutine(SceneChangeDelay(espMachine));
        }
        IEnumerator SceneChangeDelay(int buildIndex)
        {
            yield return changeLevelWaitTimer;
            SceneManager.LoadScene(buildIndex);
        }

        public void DisableSyrupCollider()
        {
            collider2D.enabled = false;
        }

        public void EnableSyrupCollider()
        {
            collider2D.enabled = true;
        }
    }
}
