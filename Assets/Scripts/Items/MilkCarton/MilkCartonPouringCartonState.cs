using System.Collections;
using UnityEngine;
namespace CoffeeCoffee.Item
{
    public class MilkCartonPouringCartonState : MilkCartonBaseState
    {
        const string POUR_MILK_ANIMATION = "PourMilk";
        public override void UpdateState(MilkCarton milkCarton)
        {
            StartMilkPour(milkCarton);
            milkCarton.StartCoroutine(DelayFinishedState(milkCarton));

        }
        public override void OnCollisionState(MilkCarton milkCarton, Collision2D otherObjectCollider)
        {

        }
        private void StartMilkPour(MilkCarton carton)
        {
            carton.GetComponent<Collider2D>().enabled = false;
            carton.rigidbody2D.freezeRotation = false;
            carton.animator.SetBool(POUR_MILK_ANIMATION, true);
        }
        IEnumerator DelayFinishedState(MilkCarton carton)
        {
            yield return new WaitForSeconds(1.5f);
            carton.SwitchState(carton.finishedMilkState);
        }
    }
}
