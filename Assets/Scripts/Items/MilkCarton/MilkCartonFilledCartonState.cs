using System.Collections;
using UnityEngine;
namespace CoffeeCoffee.Item
{
    public class MilkCartonFilledCartonState : MilkCartonBaseState
    {
        float xPosition = 25f;
        float yPosition = 75f;
        public override void UpdateState(MilkCarton milkCarton)
        {

        }

        public override void OnCollisionState(MilkCarton milkCarton, Collision2D otherObjectCollider)
        {
            if (otherObjectCollider.gameObject.GetComponent<MilkPitcher>() && !otherObjectCollider.gameObject.GetComponent<MilkPitcher>().IsFilled())
            {
                lockPosition(milkCarton, otherObjectCollider);
                milkCarton.gameObject.GetComponent<CoffeeCoffee.Functionality.DragAndDrop>().StopDragMovement();
                milkCarton.StartCoroutine(WaitForLocationSwap(milkCarton));
            }
        }
        private void lockPosition(MilkCarton milkCarton, Collision2D other)
        {
            milkCarton.rigidbody2D.position = other.gameObject.transform.position + new Vector3(xPosition, yPosition, 0);
        }
        IEnumerator WaitForLocationSwap(MilkCarton carton)
        {
            yield return new WaitForSeconds(.1f);
            carton.SwitchState(carton.pourMilkState);
        }
    }
}
