using UnityEngine;

namespace CoffeeCoffee.Item
{
    public class MilkPitcherSteamingMilkState : MilkPitcherBaseState
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
            if (milkPitcher.IsNotStreamed() == false)
            {
                milkPitcher.SwitchState(milkPitcher.fininshedSteamingState);
            }
        }
    }
}
