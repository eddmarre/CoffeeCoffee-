using System.Collections;
using UnityEngine;

namespace CoffeeCoffee.Item
{
    public class MilkPitcherFinishedSteamingState : MilkPitcherBaseState
    {
        float xPosition = 85;
        float yPosition = 120;
        public override void OnCollisinEnterState(MilkPitcher milkPitcher, Collision2D otherObjectCollider)
        {
            if (otherObjectCollider.gameObject.GetComponent<Cup>())
            {
                lockPosition(milkPitcher, otherObjectCollider);
                milkPitcher.SetMilkTypeFromDictionary();
                milkPitcher.gameObject.GetComponent<CoffeeCoffee.Functionality.DragAndDrop>().StopDragMovement();
                milkPitcher.StartCoroutine(WaitForLocationSwap(milkPitcher));
            }
        }

        public override void OnCollisionStayState(MilkPitcher milkPitcher, Collision2D otherObjectCollider)
        {

        }

        public override void OnTriggerEnterState(MilkPitcher milkPitcher, Collider2D otherObjectCollider)
        {

        }

        public override void UpdateState(MilkPitcher milkPitcher)
        {

        }
        private void lockPosition(MilkPitcher pitcher, Collision2D other)
        {
            pitcher.rigidbody2D.gravityScale = 0;
            pitcher.rigidbody2D.position = other.gameObject.transform.position + new Vector3(xPosition, yPosition, 0);
        }
        IEnumerator WaitForLocationSwap(MilkPitcher milk)
        {
            yield return new WaitForSeconds(1f);
            milk.SwitchState(milk.pourMilkState);
        }
    }
}
