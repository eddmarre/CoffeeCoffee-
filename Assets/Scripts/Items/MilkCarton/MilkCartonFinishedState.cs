using UnityEngine;
namespace CoffeeCoffee.Item
{
    public class MilkCartonFinishedState : MilkCartonBaseState
    {
        public override void UpdateState(MilkCarton milkCarton)
        {
            milkCarton.FillPitcher();
            milkCarton.DestroyThisObject();
        }
        public override void OnCollisionState(MilkCarton milkCarton, Collision2D otherObjectCollider)
        {

        }
    }
}
