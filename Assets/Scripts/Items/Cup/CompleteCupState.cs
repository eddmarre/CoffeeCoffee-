using UnityEngine.SceneManagement;

namespace CoffeeCoffee.Item
{
    public class CompleteCupState : CupBaseState
    {
        public override void UpdateState(Cup cup)
        {
            int handOff = 5;
            SceneManager.LoadScene(handOff);
        }
    }
}
