using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoffeeCoffee.EspressoMahchineButtons
{
    public class ChangeLightColor : MonoBehaviour
    {
        public Material[] materials;
        SpriteRenderer spriteRenderer;
        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.material = materials[0];
        }
        public void ChangeMaterial(int selection)
        {
            spriteRenderer.material = materials[selection];
        }
    }
}
