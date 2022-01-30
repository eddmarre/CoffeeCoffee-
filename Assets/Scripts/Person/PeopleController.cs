using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoffeeCoffee.Person
{
    public class PeopleController : MonoBehaviour
    {
        GameManager gameManager;
        public GameObject[] RandomPerson;
        public GameObject spawnLocation;
        public GameObject Canvas;
        GameObject person;
        private void Awake()
        {
            Canvas.SetActive(true);
            int randomIndex = Random.Range(0, 3);
            person = Instantiate(RandomPerson[randomIndex], spawnLocation.transform.position, Quaternion.identity);
            person.transform.localScale = new Vector3(60f, 70f, 100f);
            if (randomIndex == 0)
            {
                person.name = RandomPerson[0].gameObject.name;
            }
            else if (randomIndex == 1)
            {
                person.name = RandomPerson[1].gameObject.name;
            }
            else if (randomIndex == 2)
            {
                person.name = RandomPerson[2].gameObject.name;
            }
        }
        private void Start()
        {
            gameManager = GameManager.Instance;
            //gameManager.customerOrder =new Dialogue.Order();
           // gameManager.playerInputedOrder = new Dialogue.Order();
           // gameManager.FinalCupOrder = new Dialogue.Order();
        }

        public void DisablePerson()
        {
            foreach (People person in gameManager.currentPeople)
            {
                if (gameManager.gmPeople.Contains(person))
                {
                    person.gameObject.SetActive(true);
                }
                else
                {
                    person.gameObject.SetActive(true);
                }
            }
        }

    }
}