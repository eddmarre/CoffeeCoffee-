using UnityEngine;

namespace CoffeeCoffee.Item
{
    public abstract class EsspressoGlassBaseState
    {
        public abstract void StartState(EsspressoGlass esspressoGlass);
        public abstract void OnCollisionEnterState(EsspressoGlass esspressoGlass, Collision2D otherObjectCollider);
        public abstract void OnCollisionStayState(EsspressoGlass esspressoGlass, Collision2D otherObjectCollider);
        public abstract void OnTriggerStayState(EsspressoGlass esspressoGlass, Collider2D otherObjectCollider);
        public abstract void UpdateState(EsspressoGlass esspressoGlass);
    }
}
