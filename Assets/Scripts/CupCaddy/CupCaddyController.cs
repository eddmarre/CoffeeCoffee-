using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoffeeCoffee.CupCaddy
{
    public class CupCaddyController : MonoBehaviour
    {
        CupCaddySpawner[] spawners;

        private void Awake()
        {
            spawners = GetComponentsInChildren<CupCaddySpawner>();
        }

        private void Update()
        {
            TurnOffTriggers();
        }

        private void TurnOffTriggers()
        {
            foreach (CupCaddySpawner spawner in spawners)
            {
                if (spawner.canSpawn == false)
                {
                    foreach (CupCaddySpawner spawn in GetComponentsInChildren<CupCaddySpawner>())
                    {
                        spawn.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}