using UnityEngine;

namespace CoffeeCoffee.Item
{
    public abstract class MilkPitcherBaseState
    {
        public abstract void UpdateState(MilkPitcher milkPitcher);
        public abstract void OnCollisionStayState(MilkPitcher milkPitcher, Collision2D otherObjectCollider);
        public abstract void OnCollisinEnterState(MilkPitcher milkPitcher, Collision2D otherObjectCollider);
        public abstract void OnTriggerEnterState(MilkPitcher milkPitcher, Collider2D otherObjectCollider);
    }
}
