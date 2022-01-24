namespace CoffeeCoffee.Dialogue
{
    public class Order
    {
        public string size { get; set; }
        public string flavor { get; set; }
        public string milk { get; set; }
        public string esspresso { get; set; }
        public string beverage { get; set; }
        public string temperature { get; set; }
        public string shot { get; set; }
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
        public Order()
        {

        }

        public Order GetOrder()
        {
            return this;
        }

        public Order DeepCopy()
        {
            Order deepCopyOrder = new Order(this.size, this.shot, this.esspresso,
            this.flavor, this.beverage, this.milk, this.temperature);
            return deepCopyOrder;
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