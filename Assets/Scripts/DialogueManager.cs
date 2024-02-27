using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    private UIDocument dialogueTemplate;
    private Label charName;
    private Label message;
    private VisualElement charAvatar;
    private VisualElement root;

    private List<ScenarioElement> elements;

    public static DialogueManager Instance
    {
        get
        {
            // More Optimized
            if (instance != null) return instance;
            else return instance = FindObjectOfType<DialogueManager>();
        } 
    }

    public void Initialize(UIDocument _dialogueTemplate)
    {
        dialogueTemplate = _dialogueTemplate;
        root = dialogueTemplate.rootVisualElement;
        charName = root.Q<Label>("CharName");
        message = root.Q<Label>("Message");
        charAvatar = root.Q<VisualElement>("CharAvatar");
        root.RegisterCallback((ClickEvent evt) => 
        {
            root.style.display = DisplayStyle.None;
            if (elements.Count != 0) 
            {
                int index = Random.Range(0,elements.Count);
                elements[index].StartScenario();

            }
        });

        root.style.display = DisplayStyle.None;
    }
    public void ShowDialogue(Dialogue dialogue)
    {
        this.elements = dialogue.NextElements;
        bind(dialogue);
        root.style.display = DisplayStyle.Flex;
    }

    private void bind(Dialogue dialogue)
    {
        message.text = dialogue.Message;
        charName.text = dialogue.CharacterName;
        // ba3deeeeeeeeeeeeeeeeeeeen
    }
}
