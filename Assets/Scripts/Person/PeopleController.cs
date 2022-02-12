using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoffeeCoffee.Person
{
    public class PeopleController : MonoBehaviour
    {
        [SerializeField] GameObject[] RandomPerson;
        [SerializeField] GameObject spawnLocation;
        [SerializeField] GameObject Canvas;
        private void Awake()
        {
            Canvas.SetActive(true);
            int randomIndex = Random.Range(0, 3);
            GameObject person;
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

    }
}