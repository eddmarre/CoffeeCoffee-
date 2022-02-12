using System.Collections;
using UnityEngine;

namespace CoffeeCoffee.Item
{
    public class MilkPitcherPourMilkState : MilkPitcherBaseState
    {
        const string POUR_PITCHER_TRIGGER = "PourPitcher";
        public override void OnCollisinEnterState(MilkPitcher milkPitcher, Collision2D otherObjectCollider)
        {

        }

        public override void OnCollisionStayState(MilkPitcher milkPitcher, Collision2D otherObjectCollider)
        {

        }

        public override void OnTriggerEnterState(MilkPitcher milkPitcher, Collider2D otherObjectCollider)
        {

        }

        public override void UpdateState(MilkPitcher milkPitcher)
        {
            StartMilkPour(milkPitcher);
            milkPitcher.StartCoroutine(DelayMilkPitcherFillCup(milkPitcher));
        }
        private void StartMilkPour(MilkPitcher milkPitcher)
        {
            milkPitcher.GetComponent<Collider2D>().enabled = false;
            milkPitcher.rigidbody2D.freezeRotation = false;
            milkPitcher.animator.SetTrigger(POUR_PITCHER_TRIGGER);
        }
        IEnumerator DelayMilkPitcherFillCup(MilkPitcher milkPitcher)
        {
            yield return new WaitForSeconds(1f);
            milkPitcher.FillCup();
            milkPitcher.SwitchState(milkPitcher.finishedPourMilkState);
        }
    }
}
