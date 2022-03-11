using UnityEngine;
using CoffeeCoffee.Dialogue;

namespace CoffeeCoffee.Item
{
    public class CreateEsspresso : MonoBehaviour, ICreateEsspresso
    {
        public enum Esspresso { none, blonde, regular, decaf };
        public enum EsspressoSize { none, esingle, edouble };
        public Esspresso esspresso { get; set; }
        public EsspressoSize esspressoSize { get; set; }

        public string CupInputShots { get; private set; }
        public string CupInputEsspresso { get; private set; }



        public void SetDictionaryEsspressoShots()
        {
            OrderDictionary orderDictionary = new OrderDictionary();
            if (esspressoSize == EsspressoSize.esingle)
            {
                CupInputShots = orderDictionary.shots[0];
            }
            else if (esspressoSize == EsspressoSize.edouble)
            {
                CupInputShots = orderDictionary.shots[1];
            }
        }

        public void SetDictionaryEsspressoType()
        {
            OrderDictionary orderDictionary = new OrderDictionary();
            if (esspresso == Esspresso.blonde)
            {
                CupInputEsspresso = orderDictionary.esspressos[1];
            }
            else if (esspresso == Esspresso.regular)
            {
                CupInputEsspresso = orderDictionary.esspressos[0];
            }
            else if (esspresso == Esspresso.decaf)
            {
                CupInputEsspresso = orderDictionary.esspressos[2];
            }
        }

        public void initializeEsspresso()
        {
            esspresso = Esspresso.none;
            esspressoSize = EsspressoSize.none;
        }

        public void SetEsspressoShot(EsspressoSize size)
        {
            esspressoSize = size;
        }
    }
}
