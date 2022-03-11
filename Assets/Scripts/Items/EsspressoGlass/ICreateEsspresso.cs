namespace CoffeeCoffee.Item
{
    public interface ICreateEsspresso
    {
        public string CupInputShots { get; }
        public string CupInputEsspresso { get; }
        public void SetDictionaryEsspressoShots();
        public void SetDictionaryEsspressoType();
        public void initializeEsspresso();
    }
}
