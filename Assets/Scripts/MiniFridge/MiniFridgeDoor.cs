using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniFridgeDoor : MonoBehaviour
{
    Animator animator;
    const string OPEN_DOOR_ANIMATION = "OpenDoor";
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        animator.SetBool(OPEN_DOOR_ANIMATION, true);
    }
}
