using System.Collections.Generic;
using UnityEngine;
using CoffeeCoffee.Dialogue;
using CoffeeCoffee.EspressoMahchineButtons;

namespace CoffeeCoffee.Item
{

    public class MilkPitcher : MonoBehaviour
    {
        public MilkPitcherBaseState currentState;
        public MilkPitcherBaseState emptyState = new MilkPitcherEmptyState();
        public MilkPitcherBaseState hasMilkState = new MilkPitcherHasMilkState();
        public MilkPitcherBaseState steamingMilkState = new MilkPitcherSteamingMilkState();
        public MilkPitcherBaseState fininshedSteamingState = new MilkPitcherFinishedSteamingState();
        public MilkPitcherBaseState pourMilkState = new MilkPitcherPourMilkState();
        public MilkPitcherBaseState finishedPourMilkState = new MilkPitcherFinishedPourMilkState();
        [SerializeField] GameObject pitcherSteam;

        const string STEAMING_PITCHER = "SteamPitcher";
        const string FINISHED_STEAMING_PITCHER = "FinishedSteaming";
        const string FILL_PITCHER = "FillPitcher";


        enum MilkType { none, nonFat, twoPercent, wholeMilk };
        MilkType milkType;

        public Animator animator;
        public new Rigidbody2D rigidbody2D;
        public bool isSteaming = false;


        bool isNotSteamed = true;
        bool isFilled = false;

        float yOffset = 90.5f;
        float xOffset = -7f;

        string CupInputMilk;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            rigidbody2D = GetComponent<Rigidbody2D>();

            milkType = MilkType.none;

            pitcherSteam.SetActive(false);
        }
        private void Start()
        {
            currentState = emptyState;
        }
        private void Update()
        {
            currentState.UpdateState(this);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            currentState.OnCollisinEnterState(this, other);
        }
        private void OnCollisionStay2D(Collision2D other)
        {
            currentState.OnCollisionStayState(this, other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            currentState.OnTriggerEnterState(this, other);

        }

        public void FillCup()
        {
            try
            {
                FindObjectOfType<Cup>().FillCupMilk(CupInputMilk);
            }
            catch
            {
                Debug.LogWarning("Couldn't fill milk in cup", this);
            }
        }

        public bool IsNotStreamed()
        {
            return isNotSteamed;
        }
        public bool IsFilled()
        {
            return isFilled;
        }

        public void EnableClick()
        {
            GetComponent<Collider2D>().enabled = true;
            GetComponent<CoffeeCoffee.Functionality.DragAndDrop>().AllowDragMovement();
            rigidbody2D.gravityScale = 100;
        }
        public void DisableClick()
        {
            GetComponent<CoffeeCoffee.Functionality.DragAndDrop>().StopDragMovement();
            rigidbody2D.gravityScale = 0;
        }



        public void FillMilkPitcher()
        {
            animator.SetBool(FILL_PITCHER, true);
            isFilled = true;
        }

        public void BeginSteamingMilk()
        {
            animator.SetBool(STEAMING_PITCHER, true);
            isSteaming = true;
        }

        public void FinishedSteamingMilk()
        {
            animator.SetBool(STEAMING_PITCHER, false);
            animator.SetTrigger(FINISHED_STEAMING_PITCHER);
            pitcherSteam.gameObject.SetActive(true);
            pitcherSteam.transform.position = transform.position + new Vector3(xOffset, yOffset, 0);
            pitcherSteam.transform.SetParent(transform);
            try
            {
                SetMilkPitcherTemperature(FindObjectOfType<TemperatureButton>().GetTemperature());
            }
            catch
            {
                Debug.LogWarning("Couldn't set Cup temperature", this);
            }
            isNotSteamed = false;
        }

        void SetMilkPitcherTemperature(string temp)
        {
            FindObjectOfType<Cup>().FillCupTemperature(temp);
        }


        public void FinishMilkPour()
        {
            pitcherSteam.SetActive(false);
            gameObject.SetActive(false);
        }



        public void SetMilkType(Collision2D other)
        {
            if (other.gameObject.GetComponent<MilkCarton>() && milkType == MilkType.none)
            {
                if (other.gameObject.GetComponent<MilkCarton>().milkCartonType == MilkCarton.MilkCartonType.nonFat)
                {
                    milkType = MilkType.nonFat;
                }
                else if (other.gameObject.GetComponent<MilkCarton>().milkCartonType == MilkCarton.MilkCartonType.twoPercent)
                {
                    milkType = MilkType.twoPercent;
                }
                else if (other.gameObject.GetComponent<MilkCarton>().milkCartonType == MilkCarton.MilkCartonType.wholeMilk)
                {
                    milkType = MilkType.wholeMilk;
                }
            }
        }
        public void SetMilkTypeFromDictionary()
        {
            OrderDictionary orderDictionary = new OrderDictionary();
            if (milkType == MilkType.nonFat)
            {
                CupInputMilk = orderDictionary.milks[1];
            }
            else if (milkType == MilkType.twoPercent)
            {
                CupInputMilk = orderDictionary.milks[0];
            }
            else if (milkType == MilkType.wholeMilk)
            {
                CupInputMilk = orderDictionary.milks[2];
            }
        }
        public void SwitchState(MilkPitcherBaseState state)
        {
            currentState = state;
        }
    }
}
