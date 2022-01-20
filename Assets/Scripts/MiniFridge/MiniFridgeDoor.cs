using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoffeeCoffee.MiniFridge
{
    public class MiniFridgeDoor : MonoBehaviour
    {
        Animator animator;
        [SerializeField] GameObject itemInFridge;
        const string OPEN_DOOR_ANIMATION = "OpenDoor";
        private void Awake()
        {
            animator = GetComponent<Animator>();
            itemInFridge.SetActive(false);
        }
        private void OnMouseDown()
        {
            OpenDoor();
            itemInFridge.SetActive(true);
        }

        private void OpenDoor()
        {
            animator.SetBool(OPEN_DOOR_ANIMATION, true);
        }
    }
}
