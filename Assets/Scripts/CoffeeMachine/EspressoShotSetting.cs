using UnityEngine;
namespace CoffeeCoffee.EspressoMahchineButtons
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
            isDouble = false;
            return isDouble;
        }
        bool DoubleSetting()
        {
            ShotType[espSingle].SetActive(false);
            ShotType[espDouble].SetActive(true);
            isDouble = true;
            return isDouble;
        }

        public bool GetIsDouble()
        {
            return isDouble;
        }
    }
}