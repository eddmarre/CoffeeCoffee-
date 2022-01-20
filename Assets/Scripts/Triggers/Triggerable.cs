using UnityEngine;

namespace CoffeeCoffee.Triggers
{


    public class Triggerable:MonoBehaviour
    {
        bool isOccupied = false;
        public void ResetIsOccupied()
        {
            isOccupied = false;
        }

        public bool GetIsOccupied()
        {
            return isOccupied;
        }

        public void SetIsOccupied(bool trueOrFalse)
        {
            isOccupied = trueOrFalse;
        }
    }
}