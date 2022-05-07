using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tutorial
{
    public class CloseTutorial : MonoBehaviour
    {
        private void Awake()
        {
            Time.timeScale = 0;
        }

        public void Close()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }
    }
}