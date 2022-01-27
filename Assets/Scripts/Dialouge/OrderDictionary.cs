namespace CoffeeCoffee.Dialogue
{
    public class OrderDictionary
    {
        public string[] sizes { get; private set; }
        public string[] flavors { get; private set; }
        public string[] milks { get; private set; }
        public string[] esspressos { get; private set; }
        public string[] beverages { get; private set; }
        public string[] temperatures { get; private set; }
        public string[] shots { get; private set; }
        public OrderDictionary()
        {
            sizes = new string[] { "small", "medium", "large" };
            flavors = new string[] { "vanilla", "caramel", "hazelnut", "classic", "mocha" };
            milks = new string[] { "two percent", "nonfat", "whole" };
            esspressos = new string[] { "regular esspresso", "blonde", "decaf" };
            beverages = new string[] { "latte", "machiato", "americano" };
            temperatures = new string[] { "regular temp", "warm", "extra hot" };
            shots = new string[] { "single", "double", "triple" };
        }
    }
}