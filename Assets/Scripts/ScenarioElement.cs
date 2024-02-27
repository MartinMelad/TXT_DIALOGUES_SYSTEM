using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScenarioElement
{
    protected List<ScenarioElement> nextElements = new List<ScenarioElement>();

    public List<ScenarioElement> NextElements { get { return nextElements; } }

    public void AddScenarioElement(ScenarioElement element)
    {
        nextElements.Add(element);
    }

    public abstract void StartScenario();

}