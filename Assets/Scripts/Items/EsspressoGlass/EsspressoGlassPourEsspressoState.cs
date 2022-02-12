using System.Collections;
using UnityEngine;

namespace CoffeeCoffee.Item
{
    public class EsspressoGlassPourEsspressoState : EsspressoGlassBaseState
    {
        const string POUR_GLASS_TRIGGER = "PourGlass";
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
            StartEsspressoPour(esspressoGlass);
            esspressoGlass.StartCoroutine(DelayEsspressoGlassFillCup(esspressoGlass));
        }
        private void StartEsspressoPour(EsspressoGlass glass)
        {
            glass.GetComponent<Collider2D>().enabled = false;
            glass.rigidbody2D.freezeRotation = false;
            glass.animator.SetTrigger(POUR_GLASS_TRIGGER);
        }
        IEnumerator DelayEsspressoGlassFillCup(EsspressoGlass glass)
        {

            yield return new WaitForSeconds(1.5f);
            glass.FillCup();
            glass.SwitchState(glass.finishedEsspressoState);
        }
    }
}
