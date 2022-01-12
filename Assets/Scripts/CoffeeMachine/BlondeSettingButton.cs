using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoffeeCoffee.Buttons
{
    public class BlondeSettingButton : MonoBehaviour
    {

        public ChangeLightColor BlondeSettingLight;
        public ChangeLightColor RegularSettingLight;
        public ChangeLightColor DecafSettingLight;
        int green = 1,red =0;

        private void OnMouseDown()
        {
            BlondeSettingLight.ChangeMaterial(green);
            RegularSettingLight.ChangeMaterial(red);
            DecafSettingLight.ChangeMaterial(red);
        }
    }
}
