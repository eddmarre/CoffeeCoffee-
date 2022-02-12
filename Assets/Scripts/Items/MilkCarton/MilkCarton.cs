using System.Collections.Generic;
using UnityEngine;
namespace CoffeeCoffee.Item
{
    public class MilkCarton : MonoBehaviour
    {
        public MilkCartonBaseState currentState;
        public MilkCartonBaseState filledMilkState = new MilkCartonFilledCartonState();
        public MilkCartonBaseState pourMilkState = new MilkCartonPouringCartonState();
        public MilkCartonBaseState finishedMilkState = new MilkCartonFinishedState();

        public enum MilkCartonType { none, nonFat, twoPercent, wholeMilk };
        public MilkCartonType milkCartonType;

        public Animator animator { get; private set; }
        public new Rigidbody2D rigidbody2D { get; private set; }

        private void Awake()
        {
            animator = GetComponent<Animator>();
            rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            currentState = filledMilkState;
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            currentState.OnCollisionState(this, other);
        }
        private void Update()
        {
            currentState.UpdateState(this);
        }
        public void FillPitcher()
        {
            FindObjectOfType<MilkPitcher>().FillMilkPitcher();
        }
        public void DestroyThisObject()
        {
            Destroy(gameObject);
        }
        public void SwitchState(MilkCartonBaseState state)
        {
            currentState = state;
        }
    }
}
