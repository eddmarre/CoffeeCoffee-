using UnityEngine;
using CoffeeCoffee.Triggers;

namespace CoffeeCoffee.Item
{
    public class MilkPitcherHasMilkState : MilkPitcherBaseState
    {
        public override void OnCollisinEnterState(MilkPitcher milkPitcher, Collision2D otherObjectCollider)
        {

        }


        public override void OnCollisionStayState(MilkPitcher milkPitcher, Collision2D otherObjectCollider)
        {

        }

        public override void OnTriggerEnterState(MilkPitcher milkPitcher, Collider2D otherObjectCollider)
        {
            if (otherObjectCollider.GetComponent<MilkPitcherTrigger>())
            {
                LockPositionMilkPitcher(milkPitcher, otherObjectCollider);
                milkPitcher.DisableClick();
            }
        }

        public override void UpdateState(MilkPitcher milkPitcher)
        {
            if (milkPitcher.isSteaming)
            {
                milkPitcher.SwitchState(milkPitcher.steamingMilkState);
            }
        }
        private void LockPositionMilkPitcher(MilkPitcher pitcher, Collider2D other)
        {
            pitcher.rigidbody2D.position = other.transform.position;
           // pitcher.rigidbody2D.gravityScale=0;
        }
    }
}
