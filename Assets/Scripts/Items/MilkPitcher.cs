using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkPitcher : MonoBehaviour
{
    Animator animator;
    const string STEAMING_PITCHER = "SteamPitcher";
    const string FINISHED_STEAMING_PITCHER = "FinishedSteaming";
    const string FILL_PITCHER="FillPitcher";
    bool isNotSteamed = true;
    bool isFilled=false;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void BeginSteamingMilk()
    {
        animator.SetBool(STEAMING_PITCHER, true);
    }
    public void FinishedSteamingMilk()
    {
        animator.SetBool(STEAMING_PITCHER, false);
        animator.SetTrigger(FINISHED_STEAMING_PITCHER);
        isNotSteamed = false;
    }
    public void FillMilkPitcher()
    {
        animator.SetBool(FILL_PITCHER,true);
        isFilled=true;
    }

    public bool IsNotStreamed()
    {
        return isNotSteamed;
    }

    public bool IsFilled()
    {
        return isFilled;
    }
}
