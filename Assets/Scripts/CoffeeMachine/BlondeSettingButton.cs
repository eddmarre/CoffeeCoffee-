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
        DecafSettingButton decafButton;
        RegularSettingButton regularButton;
        bool isActive = false;
        int green = 1, red = 0;

        private void Awake()
        {
            decafButton = FindObjectOfType<DecafSettingButton>();
            regularButton = FindObjectOfType<RegularSettingButton>();
        }
        private void OnMouseDown()
        {
            BlondeSettingLight.ChangeMaterial(green);
            RegularSettingLight.ChangeMaterial(red);
            DecafSettingLight.ChangeMaterial(red);
            SetActiveButton();
        }
        public void SetInActive()
        {
            isActive = false;
        }
        public void SetActiveButton()
        {
            isActive = true;
            decafButton.SetInActive();
            regularButton.SetInActive();
        }
        public bool GetIsActive()
        {
            return isActive;
        }
    }
}
