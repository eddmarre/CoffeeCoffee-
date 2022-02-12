using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerOrderInfo : MonoBehaviour
{
    TextMeshProUGUI tmp;
    [SerializeField] CupOrderManagerScriptableObject cupOrderManager;
    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        try
        {
            tmp.text = cupOrderManager.playerInputedOrder.ToString();
        }
        catch
        {
            Debug.Log("no customer order", this);
        }
    }
}
