using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : BaseScenario
{
    string title;
    List<string> choicesTitles = new List<string>();

    public string Title { get { return title; } set { title = value; } }
    public List<string> ChoicesTitles { get { return choicesTitles; } }

    public void AddChoice(string choice)
    {
        choicesTitles.Add(choice);
    }
    protected override void StartScenario()
    {
        
    }
}
