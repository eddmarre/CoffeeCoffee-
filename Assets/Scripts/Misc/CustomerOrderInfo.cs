using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerOrderInfo : MonoBehaviour
{
    TextMeshProUGUI tmp;
    GameManager gameManager;
    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
        try
        {
            tmp.text = gameManager.playerInputedOrder.ToString();
        }
        catch
        {
            Debug.Log("no customer order", this);
        }
    }
}
