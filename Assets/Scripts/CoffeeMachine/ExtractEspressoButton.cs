using UnityEngine;
using CoffeeCoffee;
using CoffeeCoffee.Functionality;
namespace CoffeeCoffee.Buttons
{
    class ExtractEspressoButton : MonoBehaviour
    {
        public GameObject esspressoGlassTrigger;
        private void OnMouseDown()
        {
            Debug.Log("EsspressoButton Pressed");
            esspressoGlassTrigger.SetActive(false);
            FindObjectOfType<DragAndDrop>().EnableClick();
            FindObjectOfType<EsspressoGlass>().PourEsspressoIntoShotGlass();
        }
    }
}