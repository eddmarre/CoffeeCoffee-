using UnityEngine;
namespace CoffeeCoffee.Buttons
{
    public class LeverControls : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Debug.Log("Lever Pulled", this);
        }
    }
}