using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Dialogue;
using CoffeeCoffee.Item;

namespace CoffeeCoffee.CupCaddy
{
    public class CupCaddySpawner : MonoBehaviour
    {
        public GameObject cup;
        public enum SpawnerSize { small, medium, large };
        public SpawnerSize spawnCupSize;
        float yOffset = 150f;
        string CupInputSize;
        public bool canSpawn { get; set; }
        private void Start()
        {
            canSpawn = true;
        }

        private void OnMouseDown()
        {
            if (canSpawn)
            {
                var thisCupGameObject = Instantiate(cup, transform.position + new Vector3(0, yOffset, 0), Quaternion.identity);
                var thisCup = thisCupGameObject.GetComponentInChildren<Cup>();
                if (spawnCupSize == SpawnerSize.small)
                {
                    thisCup.cupSize = Cup.CupSize.small;
                }
                else if (spawnCupSize == SpawnerSize.medium)
                {
                    thisCup.cupSize = Cup.CupSize.medium;
                }
                else if (spawnCupSize == SpawnerSize.large)
                {
                    thisCup.cupSize = Cup.CupSize.large;
                }
                canSpawn = false;
            }
        }
    }
}
