namespace CoffeeCoffee.Item
{
    public class HasSyrupState : CupBaseState
    {
        public override void UpdateState(Cup cup)
        {
            if (cup.CupOrder.esspresso != null && cup.CupOrder.milk == null)
            {
                cup.CupOrder.beverage = orderDictionary.beverages[0];
                cup.SwitchState(cup.latteState);
            }
            else if (cup.CupOrder.esspresso == null && cup.CupOrder.milk != null)
            {
                cup.CupOrder.beverage = orderDictionary.beverages[1];
                cup.SwitchState(cup.machiattoState);
            }
        }
    }
}
