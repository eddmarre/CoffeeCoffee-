using UnityEngine;
using CoffeeCoffee.Triggers;

namespace CoffeeCoffee.Item
{
    public class MilkPitcherEmptyState : MilkPitcherBaseState
    {

        public override void OnCollisinEnterState(MilkPitcher milkPitcher, Collision2D otherObjectCollider)
        {
            if (otherObjectCollider.gameObject.GetComponent<MilkCarton>())
            {
                milkPitcher.SetMilkType(otherObjectCollider);
                milkPitcher.SwitchState(milkPitcher.hasMilkState);
            }
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

        }

        private void LockPositionMilkPitcher(MilkPitcher pitcher, Collider2D other)
        {
            pitcher.rigidbody2D.position = other.transform.position;
        }
    }
}
