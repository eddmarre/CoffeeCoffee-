using System.Collections;
using UnityEngine;

namespace CoffeeCoffee.Item
{
    public class EsspressoGlassHasEsspressoState : EsspressoGlassBaseState
    {

        float xPosition = 50;
        float yPosition = 120;
        public override void OnCollisionEnterState(EsspressoGlass esspressoGlass, Collision2D otherObjectCollider)
        {
            if (otherObjectCollider.gameObject.GetComponent<Cup>())
            {
                LockPositionEsspressoGlass(esspressoGlass, otherObjectCollider);
                esspressoGlass.gameObject.GetComponent<CoffeeCoffee.Functionality.DragAndDrop>().StopDragMovement();
                esspressoGlass.StartCoroutine(WaitForLocationSwap(esspressoGlass));
            }
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

        }
        private void LockPositionEsspressoGlass(EsspressoGlass esspressoGlass, Collision2D other)
        {
            esspressoGlass.rigidbody2D.gravityScale = 0;
            esspressoGlass.rigidbody2D.position = other.transform.position + new Vector3(xPosition, yPosition, 0);
        }
        IEnumerator WaitForLocationSwap(EsspressoGlass glass)
        {
            yield return new WaitForSeconds(.5f);
            glass.SwitchState(glass.pourEsspressoState);
        }


    }
}
