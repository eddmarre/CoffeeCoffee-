using UnityEngine;

public class ResetOrders : MonoBehaviour
{
    [SerializeField]CupOrderManagerScriptableObject manager;

    public void ResetManager()
    {
        manager.ResetOrder();
    }
}