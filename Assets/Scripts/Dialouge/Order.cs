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
            return size + " " + shot + " " + esspresso + " " + flavor + " " + beverage + " " + temperature + " " + milk;
        }
        public override bool Equals(object obj)
        {
            if (size == ((Order)obj).size &&
            flavor == ((Order)obj).flavor &&
            milk == ((Order)obj).milk &&
            esspresso == ((Order)obj).esspresso &&
            beverage == ((Order)obj).beverage &&
            temperature == ((Order)obj).temperature &&
            shot == ((Order)obj).shot)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}