using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScenario
{
    protected List<BaseScenario> nextScenarios = new List<BaseScenario>();

    protected List<BaseScenario> NextScenarios { get { return nextScenarios; } }

    protected void AddScenario(BaseScenario scenario)
    {
        nextScenarios.Add(scenario);
    }

    public void GoNext(int index)
    {
        if (index < nextScenarios.Count)
        {
            nextScenarios[index].StartScenario();
        }
    }
    protected abstract void StartScenario();



}
