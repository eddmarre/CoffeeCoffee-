namespace CoffeeCoffee.Item
{
    public class MachiatoState : CupBaseState
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
