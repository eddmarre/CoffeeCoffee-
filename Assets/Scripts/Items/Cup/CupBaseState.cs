using CoffeeCoffee.Dialogue;

namespace CoffeeCoffee.Item
{
    public abstract class CupBaseState
    {
        protected OrderDictionary orderDictionary = new OrderDictionary();
        public abstract void UpdateState(Cup cup);
    }
}
