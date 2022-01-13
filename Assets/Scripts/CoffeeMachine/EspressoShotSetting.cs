using UnityEngine;
namespace CoffeeCoffee.Buttons
{
    public class EspressoShotSetting : MonoBehaviour
    {
        public GameObject[] ShotType;
        int espSingle = 0, espDouble = 1;
        bool isDouble;
        private void OnMouseDown()
        {
            var SingleOrDouble = isDouble ? SingleSetting() : DoubleSetting();
        }

        bool SingleSetting()
        {
            ShotType[espSingle].SetActive(true);
            ShotType[espDouble].SetActive(false);
            return (isDouble = false);
        }
        bool DoubleSetting()
        {
            ShotType[espSingle].SetActive(false);
            ShotType[espDouble].SetActive(true);
            return (isDouble = true);
        }

        public bool GetIsDouble()
        {
            return isDouble;
        }
    }
}