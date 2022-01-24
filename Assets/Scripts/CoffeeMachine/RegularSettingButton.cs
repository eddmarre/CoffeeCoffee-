using UnityEngine;
using CoffeeCoffee;
using CoffeeCoffee.EspressoMahchineButtons;

namespace CoffeeCoffee.EspressoMahchineButtons
{
    public class RegularSettingButton : MonoBehaviour
    {

        public ChangeLightColor BlondeSettingLight;
        public ChangeLightColor RegularSettingLight;
        public ChangeLightColor DecafSettingLight;

        DecafSettingButton decafButton;
        BlondeSettingButton blondeButton;
        int green = 1, red = 0;
        bool isActive = false;
        private void Awake()
        {
            decafButton = FindObjectOfType<DecafSettingButton>();
            blondeButton = FindObjectOfType<BlondeSettingButton>();
        }
        private void Start()
        {
            RegularSettingLight.ChangeMaterial(green);
            SetActiveButton();
        }
        private void OnMouseDown()
        {
            BlondeSettingLight.ChangeMaterial(red);
            RegularSettingLight.ChangeMaterial(green);
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
            blondeButton.SetInActive();
        }
        public bool GetIsActive()
        {
            return isActive;
        }
    }
}