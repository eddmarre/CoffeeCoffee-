using UnityEngine;
namespace CoffeeCoffee.Item
{
    public abstract class MilkCartonBaseState
    {
        public abstract void UpdateState(MilkCarton milkCarton);
        public abstract void OnCollisionState(MilkCarton milkCarton, Collision2D otherObjectCollider);
    }
}
