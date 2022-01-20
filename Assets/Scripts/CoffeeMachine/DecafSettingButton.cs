using UnityEngine;
namespace CoffeeCoffee.Buttons
{
    public class DecafSettingButton : MonoBehaviour
    {


        public ChangeLightColor BlondeSettingLight;
        public ChangeLightColor RegularSettingLight;
        public ChangeLightColor DecafSettingLight;
        BlondeSettingButton blondeButton;
        RegularSettingButton regularButton;
        int green = 1, red = 0;
        bool isActive=false;
        private void Awake()
        {
            blondeButton=FindObjectOfType<BlondeSettingButton>();
            regularButton=FindObjectOfType<RegularSettingButton>();
        }
        private void OnMouseDown()
        {
            BlondeSettingLight.ChangeMaterial(red);
            RegularSettingLight.ChangeMaterial(red);
            DecafSettingLight.ChangeMaterial(green);
            SetActiveButton();
        }
        public void SetInActive()
        {
            isActive = false;
        }
        public void SetActiveButton()
        {
            isActive = true;
            regularButton.SetInActive();
            blondeButton.SetInActive();
        }
        public bool GetIsActive()
        {
            return isActive;
        }
    }
}