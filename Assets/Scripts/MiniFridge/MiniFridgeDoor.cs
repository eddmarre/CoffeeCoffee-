using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoffeeCoffee.MiniFridge
{
    public class MiniFridgeDoor : MonoBehaviour
    {
        const string OPEN_DOOR_ANIMATION = "OpenDoor";
        Animator animator;
        [SerializeField] GameObject itemInFridge;
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
