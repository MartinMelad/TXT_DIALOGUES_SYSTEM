using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ScenarioAction : ScenarioElement
{
    MethodInfo action = null;
    object[] parameters;
    int parameter;
    Type type;


    public int Parameter { get { return parameter; } set { parameter = value; } }

    public ScenarioAction(MethodInfo action, Type type)
    {
        this.action = action;
        parameter = 0;
        parameters = null;
        this.type = type;

    }
    public ScenarioAction(MethodInfo action, int parameter, Type type)
    {
        this.action = action;
        this.parameter = parameter;
        parameters = new object[] { parameter };
        this.type = type;
    }

    public override void StartScenario()
    {
        if (action != null)
        {
            action.Invoke(type, parameters);
        }
        Debug.Log("Method Invoked");
        int index = UnityEngine.Random.Range(0, nextElements.Count);
        nextElements[index].StartScenario();
    }
}
