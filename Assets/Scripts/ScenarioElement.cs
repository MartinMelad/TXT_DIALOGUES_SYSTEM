using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScenarioElement
{
    protected List<ScenarioElement> nextElements = new List<ScenarioElement>();
    protected string codeName = "";
    protected string condition = "";

    public List<ScenarioElement> NextElements { get { return nextElements; } }
    public string CodeName { get { return codeName; } set { codeName = value; } }
    public string Condition { get { return condition; } set {  condition = value; } }

    public void AddScenarioElement(ScenarioElement element)
    {
        nextElements.Add(element);
    }
    public abstract void StartScenario();

    protected void AddToDoneScenarios()
    {
        if (codeName != "")
        {
            Scenario.doneScenarios.Add(CodeName);
        }
    }
}
