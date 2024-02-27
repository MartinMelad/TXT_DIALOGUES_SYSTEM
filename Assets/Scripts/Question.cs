using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : ScenarioElement
{
    string title;
    List<string> choicesTitles = new List<string>();

    public string Title { get { return title; } set { title = value; } }
    public List<string> ChoicesTitles { get { return choicesTitles; } }

    public Question(string title)
    {
        this.title = title;
    }

    public void AddChoice(string choice)
    {
        choicesTitles.Add(choice);
    }
    public override void StartScenario()
    {
        Debug.Log(title);
        Debug.Log(choicesTitles);
    }
}
