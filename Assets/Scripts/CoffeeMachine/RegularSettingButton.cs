using UnityEngine;
using CoffeeCoffee;

namespace CofffeCoffee.Buttons
{
    public class RegularSettingButton : MonoBehaviour
    {

        public ChangeLightColor BlondeSettingLight;
        public ChangeLightColor RegularSettingLight;
        public ChangeLightColor DecafSettingLight;
        int green = 1, red = 0;
        private void Start()
        {
            RegularSettingLight.ChangeMaterial(green);
        }
        private void OnMouseDown()
        {
            BlondeSettingLight.ChangeMaterial(red);
            RegularSettingLight.ChangeMaterial(green);
            DecafSettingLight.ChangeMaterial(red);
        }
    }
}