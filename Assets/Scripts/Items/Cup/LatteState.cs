namespace CoffeeCoffee.Item
{
    public class LatteState : CupBaseState
    {
        public override void UpdateState(Cup cup)
        {
            if (cup.CupOrder.milk != null && cup.CupOrder.esspresso != null)
            {
                cup.SetFinalCupOrder();
                cup.SwitchState(cup.completeCupState);
            }
        }
    }
}
