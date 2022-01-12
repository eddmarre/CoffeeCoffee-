using UnityEngine;
namespace CoffeeCoffee.Buttons
{
    public class DecafSettingButton : MonoBehaviour
    {


        public ChangeLightColor BlondeSettingLight;
        public ChangeLightColor RegularSettingLight;
        public ChangeLightColor DecafSettingLight;
        int green = 1, red = 0;
        private void OnMouseDown()
        {
            BlondeSettingLight.ChangeMaterial(red);
            RegularSettingLight.ChangeMaterial(red);
            DecafSettingLight.ChangeMaterial(green);
        }
    }
}