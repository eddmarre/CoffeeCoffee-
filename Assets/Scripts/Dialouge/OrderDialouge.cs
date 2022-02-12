namespace CoffeeCoffee.Dialogue
{
    public class OrderDialouge
    {
        string greeting;
        OrderDictionary orderDictionary = new OrderDictionary();
        Order thisOrder;
        public string CreateDialougeOrder(string _greeting, int _sizeIndex, int _shots, int _flavorIndex, int _milkIndex, int _esspressoIndex,
        int _beverageIndex, int _temperaure)
        {

            CreateOrder(_sizeIndex, _shots, _flavorIndex, _milkIndex, _esspressoIndex, _beverageIndex, _temperaure);

            return _greeting + " " + orderDictionary.sizes[_sizeIndex] + ", " + orderDictionary.shots[_shots] + " " + orderDictionary.esspressos[_esspressoIndex] + " " + orderDictionary.flavors[_flavorIndex] + " "
            + orderDictionary.beverages[_beverageIndex] + " with " + orderDictionary.temperatures[_temperaure] + ", " + orderDictionary.milks[_milkIndex] + " milk.";
        }

        private void CreateOrder(int _sizeIndex, int _shots, int _flavorIndex, int _milkIndex, int _esspressoIndex, int _beverageIndex, int _temperaure)
        {
            thisOrder = new Order(orderDictionary.sizes[_sizeIndex], orderDictionary.shots[_shots], orderDictionary.esspressos[_esspressoIndex],
            orderDictionary.flavors[_flavorIndex], orderDictionary.beverages[_beverageIndex], orderDictionary.milks[_milkIndex], orderDictionary.temperatures[_temperaure]);
        }

        public Order GetDialougeOrder()
        {
            return thisOrder.GetOrder();
        }
    }
}