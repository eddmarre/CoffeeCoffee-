using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace CoffeeCoffee.Monitor
{
    public class MonitorButton : MonoBehaviour
    {
        public enum ButtonType { sizeButton, shotButton, espressoButton, beverageButton, temperatureButton, milkButton, syrupButton };
        public ButtonType buttonType;
        public bool isPressed { get; private set; }
        Image image;
        Color originalColor;
        private void Awake()
        {
            isPressed = false;
            image = GetComponent<Image>();
        }

        private void Start()
        {
            originalColor = image.color;
        }

        private void Update()
        {
            var changeSelectedColor = isPressed ? SelectedColor() : OriginalColor();
        }

        private Color OriginalColor()
        {
            image.color = originalColor;
            return image.color;
        }

        private Color SelectedColor()
        {
            image.color = Color.red;
            return image.color;
        }
    }
}