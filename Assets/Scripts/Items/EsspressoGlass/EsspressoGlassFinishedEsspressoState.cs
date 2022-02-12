using System.Collections;
using UnityEngine;

namespace CoffeeCoffee.Item
{
    public class EsspressoGlassFinishedEsspressoState : EsspressoGlassBaseState
    {
        public override void OnCollisionEnterState(EsspressoGlass esspressoGlass, Collision2D otherObjectCollider)
        {

        }

        public override void OnCollisionStayState(EsspressoGlass esspressoGlass, Collision2D otherObjectCollider)
        {

        }

        public override void OnTriggerStayState(EsspressoGlass esspressoGlass, Collider2D otherObjectCollider)
        {

        }

        public override void StartState(EsspressoGlass esspressoGlass)
        {

        }

        public override void UpdateState(EsspressoGlass esspressoGlass)
        {
            esspressoGlass.StartCoroutine(DelayFinishEsspressoPour(esspressoGlass));
        }

        IEnumerator DelayFinishEsspressoPour(EsspressoGlass glass)
        {
            yield return new WaitForSeconds(1f);
            glass.FinishEsspressoPour();
        }
    }
}
