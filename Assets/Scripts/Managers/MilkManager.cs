using System.Collections;
using System.Collections.Generic;
using CoffeeCoffee.Item;
using UnityEngine;

public class MilkManager : MonoBehaviour
{
    MilkCarton[] milks;
    [SerializeField] GameObject MiniFridge;
    void Start()
    {
        milks = GetComponentsInChildren<MilkCarton>();
    }
    private void Update()
    {
        var currentMilks = GetComponentsInChildren<MilkCarton>();
        if (milks.Length != currentMilks.Length)
        {
            foreach (MilkCarton milk in currentMilks)
            {
                StartCoroutine(DestroyMilkCartonDelay(milk));
            }

            StartCoroutine(DestroyMiniFridgeDelay());
        }
    }

    IEnumerator DestroyMiniFridgeDelay()
    {
        yield return new WaitForSeconds(.5f);
        MiniFridge.SetActive(false);
    }
    IEnumerator DestroyMilkCartonDelay(MilkCarton _milk)
    {
        yield return new WaitForSeconds(.3f);
        try
        {
            _milk.DestroyThisObject();
        }
        catch{ }
    }
}
