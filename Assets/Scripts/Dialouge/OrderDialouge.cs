namespace CoffeeCoffee.Dialogue
{
    public class OrderDialouge
    {
        string greeting;

        string[] sizes = { "small", "medium", "large" };
        string[] flavors = { "vanilla", "caramel", "hazelnut", "classic", "mocha" };
        string[] milks = { "regular", "nonfat", "whole" };
        string[] esspressos = { "regular", "blonde", "decaf" };
        string[] beverages = { "latte", "cappuchino", "americano" };
        string[] temperatures = { "warm", "extra hot" };
        string[] shots = { "single", "double", "triple" };

        Order thisOrder;

        public string CreateDialougeOrder(string _greeting, int _sizeIndex, int _shots, int _flavorIndex, int _milkIndex, int _esspressoIndex,
        int _beverageIndex, int _temperaure)
        {
            thisOrder = new Order(sizes[_sizeIndex], shots[_shots], esspressos[_esspressoIndex], 
            flavors[_flavorIndex], beverages[_beverageIndex], milks[_milkIndex], temperatures[_temperaure]);
            return _greeting + " " + sizes[_sizeIndex] + " " + shots[_shots] + " " + esspressos[_esspressoIndex] + " " + flavors[_flavorIndex] + " "
            + beverages[_beverageIndex] + " with " + temperatures[_temperaure] + " " + milks[_milkIndex] + " milk";
        }

        public Order FindOrder()
        {
            return thisOrder.GetOrder();
        }
    }
}