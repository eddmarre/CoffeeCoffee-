using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Dialogue;
using CoffeeCoffee.Item;

namespace CoffeeCoffee.CupCaddy
{
    public class CupCaddySpawner : MonoBehaviour
    {
        public Cup cup;
        public enum SpawnerSize { small, medium, large };
        public SpawnerSize spawnCupSize;

        public bool canSpawn { get; set; }
        
        float yOffset = 150f;
        string CupInputSize;
 
        private void Start()
        {
            canSpawn = true;
        }

        private void OnMouseDown()
        {
            if (canSpawn)
            {
                Cup thisCup = InstantiateCup();
                AssignCupSize(thisCup);
            }
        }

        private Cup InstantiateCup()
        {
            var thisCupGameObject = Instantiate(cup.gameObject, transform.position + new Vector3(0, yOffset, 0), Quaternion.identity);
            var thisCup = thisCupGameObject.GetComponent<Cup>();
            return thisCup;
        }

        private void AssignCupSize(Cup thisCup)
        {
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
