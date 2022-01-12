using System.Collections;
using UnityEngine;
namespace CoffeeCoffee.Buttons
{
    public class LeverControls : MonoBehaviour
    {
        public GameObject animatedLever;
        float increaseBy = 10f;
        float decreaseBy = -10f;
        WaitForSeconds LeverTimer;
        const float TIME = .1f;
        bool isPulled = false;
        private void Awake()
        {
            LeverTimer = new WaitForSeconds(TIME);
        }
        private void OnMouseDown()
        {
            StopAllCoroutines();
            var pullLeverUpOrDown = isPulled ? StartCoroutine(PullLeverUP()) : StartCoroutine(PullLeverDown());
        }
        IEnumerator PullLeverDown()
        {
            isPulled = true;
            animatedLever.transform.Rotate(new Vector3(0, 0, decreaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, decreaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, decreaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, decreaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, decreaseBy));
            yield return LeverTimer;
        }
        IEnumerator PullLeverUP()
        {
            isPulled = false;
            animatedLever.transform.Rotate(new Vector3(0, 0, increaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, increaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, increaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, increaseBy));
            yield return LeverTimer;
            animatedLever.transform.Rotate(new Vector3(0, 0, increaseBy));
            yield return LeverTimer;
        }
    }
}