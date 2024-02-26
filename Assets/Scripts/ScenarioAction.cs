using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScenarioAction : BaseScenario
{
    UnityAction action;

    public UnityAction SetAction { set { action = value; } }
    protected override void StartScenario()
    {
        if (action != null) action.Invoke();
    }
}
