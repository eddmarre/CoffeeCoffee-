using UnityEngine;

namespace CoffeeCoffee.Item
{
    public class MilkPitcherFinishedPourMilkState : MilkPitcherBaseState
    {
        public override void OnCollisinEnterState(MilkPitcher milkPitcher, Collision2D otherObjectCollider)
        {

        }

        public override void OnCollisionStayState(MilkPitcher milkPitcher, Collision2D otherObjectCollider)
        {

        }

        public override void OnTriggerEnterState(MilkPitcher milkPitcher, Collider2D otherObjectCollider)
        {

        }

        public override void UpdateState(MilkPitcher milkPitcher)
        {
            milkPitcher.FinishMilkPour();
        }
    }
}
