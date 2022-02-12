using System.Collections;
using UnityEngine;

namespace CoffeeCoffee.Item
{
    public class EmptyCupState : CupBaseState
    {
        public override void UpdateState(Cup cup)
        {
            try
            {
                if (cup.CupOrder.flavor != null)
                {
                    cup.SwitchState(cup.hasSyrupState);
                }
            }
            catch
            {
                Debug.Log("No syrup in current cup");
            }
        }
    }
}
