using System.Collections;
using UnityEngine;
using CoffeeCoffee.Triggers;

namespace CoffeeCoffee.Item
{
    public class EsspressoGlassEmptyState : EsspressoGlassBaseState
    {
        public override void OnCollisionEnterState(EsspressoGlass esspressoGlass, Collision2D otherObjectCollider)
        {

        }

        public override void OnCollisionStayState(EsspressoGlass esspressoGlass, Collision2D otherObjectCollider)
        {

        }

        public override void OnTriggerStayState(EsspressoGlass esspressoGlass, Collider2D otherObjectCollider)
        {
            if (otherObjectCollider.gameObject.GetComponent<EsspressoGlassTrigger>())
            {
                LockPositionEsspressoGlass(esspressoGlass, otherObjectCollider);
                esspressoGlass.DisableClick();
            }
        }

        public override void StartState(EsspressoGlass esspressoGlass)
        {

        }

        public override void UpdateState(EsspressoGlass esspressoGlass)
        {
            if (esspressoGlass.IsEmpty() == false)
            {
                esspressoGlass.EnableClick();
                esspressoGlass.StartCoroutine(DelayStateSwitch(esspressoGlass));
            }
        }
        private void LockPositionEsspressoGlass(EsspressoGlass esspressoGlass, Collider2D other)
        {
            esspressoGlass.rigidbody2D.position = other.transform.position;
        }

        IEnumerator DelayStateSwitch(EsspressoGlass glass)
        {
            yield return new WaitForSeconds(1f);
            glass.SwitchState(glass.hasEsspressoState);
        }
    }
}
