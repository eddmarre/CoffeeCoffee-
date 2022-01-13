using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkPitcher : MonoBehaviour
{
    Animator animator;
    const string STEAMING_PITCHER_TRIGGER = "FillPitcher";
    const string FINISHED_STEAMING_PITCHER = "FinishedSteaming";
    bool isNotSteamed = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void BeginSteamingMilk()
    {
        animator.SetBool(STEAMING_PITCHER_TRIGGER, true);
    }
    public void FinishedSteamingMilk()
    {
        animator.SetBool(STEAMING_PITCHER_TRIGGER, false);
        animator.SetTrigger(FINISHED_STEAMING_PITCHER);
        isNotSteamed = false;
    }

    public bool IsNotStreamed()
    {
        return isNotSteamed;
    }
}
