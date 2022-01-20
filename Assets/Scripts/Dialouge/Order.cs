namespace CoffeeCoffee.Dialogue
{
    public class Order
    {
        string size;
        string flavor;
        string milk;
        string esspresso;
        string beverage;
        string temperature;
        string shot;
        public Order(string _size, string _shot, string _esspresso, string _flavor, string _beverage, string _milk, string _temperature)
        {
            size = _size;
            flavor = _flavor;
            milk = _milk;
            esspresso = _esspresso;
            beverage = _beverage;
            temperature = _temperature;
            shot = _shot;
        }

        public Order GetOrder()
        {
            return this;
        }

        public override string ToString()
        {
            return size + " " + flavor + " " + milk + " " + esspresso + " " + beverage + " " + temperature + " " + shot;
        }
    }
}