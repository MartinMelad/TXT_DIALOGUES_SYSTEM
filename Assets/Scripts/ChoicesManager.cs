using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public static class ChoicesManager 
{
    private static VisualTreeAsset choiceCard;
    private static VisualElement root;
    private static VisualElement choicesList;
    private static Label questionLable;

    public static void Initialize(UIDocument choicesUI, VisualTreeAsset _choiceCard)
    {
        root = choicesUI.rootVisualElement;
        choiceCard = _choiceCard;
        choicesList = root.Q<VisualElement>("ChoicesList");
        questionLable = root.Q<Label>("Question");

        root.style.display = DisplayStyle.None;
    }

    public static void ShowChoices(Question question)
    {
        choicesList.Clear();
        root.style.display = DisplayStyle.Flex;
        questionLable.text = question.Title;
        for (int i = 0; i < question.ChoicesTitles.Count; i++)
        {
            VisualElement _choice = choiceCard.Instantiate();
            Button choiceBut = _choice.Q<Button>("Choice");
            choiceBut.text = question.ChoicesTitles[i];
            choiceBut.clicked += () =>
            {
                root.style.display = DisplayStyle.None;
                if (question.NextElements.Count !=  0 )
                {
                    question.NextElements[i].StartScenario();
                }

            };

            choicesList.Add(_choice);

        }
    }
}
