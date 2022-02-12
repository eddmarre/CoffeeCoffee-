using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Item;
using CoffeeCoffee.Dialogue;
using UnityEngine.SceneManagement;
using System;

namespace CoffeeCoffee.Syrup
{
    public class Syrup : MonoBehaviour
    {
        [SerializeField] enum SyrupFlavor { vanilla, caramel, hazelnut, classic, mocha };
        [SerializeField] SyrupFlavor syrupFlavor;
        [SerializeField] GameObject syrupParticleEffect;
        [SerializeField] Transform spawnLocation;

        public event Action<String> onSyrupPumpAction;
        public bool isUsed { get; private set; }

        const float LEVEL_CHANGE_DELAY = 1f;

        new Collider2D collider2D;
        WaitForSeconds changeLevelWaitTimer;

        string CupInputFlavor;
        private void Awake()
        {
            collider2D = GetComponent<Collider2D>();

            isUsed = false;

            changeLevelWaitTimer = new WaitForSeconds(LEVEL_CHANGE_DELAY);
        }

        private void Start()
        {
            AssignFlavorTypeFromDictionary();
        }
        private void AssignFlavorTypeFromDictionary()
        {
            OrderDictionary orderDictionary = new OrderDictionary();
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
            PourSyrup();

            StartCoroutine(SceneChangeDelay());
        }

        private void PourSyrup()
        {
            var syrupPour = Instantiate(syrupParticleEffect, spawnLocation.position, Quaternion.identity);
            Destroy(syrupPour, 2f);
            if (onSyrupPumpAction != null)
            {
                onSyrupPumpAction(CupInputFlavor);
            }
        }

        IEnumerator SceneChangeDelay()
        {
            yield return changeLevelWaitTimer;
            var level = gameObject.AddComponent<CoffeeCoffee.SceneController.levelChanger>();
            level.SetEsspressoMachineScene();
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
