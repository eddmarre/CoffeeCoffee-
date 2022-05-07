using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class CloseButton : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                FindObjectOfType<CloseTutorial>().Close();
            }
        }
    }
}