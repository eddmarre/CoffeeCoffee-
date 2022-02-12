using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Dialogue;
using CoffeeCoffee.Item;

namespace CoffeeCoffee.CupCaddy
{
    public class CupCaddySpawner : MonoBehaviour
    {
        [SerializeField]  Cup cup;
        [SerializeField]  enum SpawnerSize { small, medium, large };
        [SerializeField]  SpawnerSize spawnCupSize;

        public bool canSpawn { get; private set; }
        
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

        private void AssignCupSize(Cup currentCup)
        {
            if (spawnCupSize == SpawnerSize.small)
            {
                currentCup.cupSize = Cup.CupSize.small;
            }
            else if (spawnCupSize == SpawnerSize.medium)
            {
                currentCup.cupSize = Cup.CupSize.medium;
            }
            else if (spawnCupSize == SpawnerSize.large)
            {
                currentCup.cupSize = Cup.CupSize.large;
            }
            canSpawn = false;
        }
    }
}
