using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace CoffeeCoffee.SceneController
{


    public class levelChanger : MonoBehaviour
    {
        //build order int reference
        const int register = 2, espMachine = 3, syrups = 4;
        public void SetEsspressoMachineScene()
        {
            ChangeLevel(espMachine);
        }

        public void setRegisterScene()
        {
            ChangeLevel(register);
        }
        public void setSyrupScene()
        {
            ChangeLevel(syrups);
        }

        private static void ChangeLevel(int index)
        {
            if (SceneManager.GetActiveScene().buildIndex != index)
            {
                SceneManager.LoadScene(index);
            }
        }

    }
}
