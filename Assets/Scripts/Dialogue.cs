using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : ScenarioElement
{

    Sprite avatar;
    string characterName;
    string message;

    public Sprite Avatar { get { return avatar; } set { avatar = value; } }
    public string CharacterName { get { return characterName; } set { characterName = value; } }
    public string Message { get { return message; } set { message = value; } }

    public Dialogue(string message)
    {
        this.message = message;
    }
    public Dialogue(string name, string message)
    {
        this.message = message;
        this.characterName = name;
    }

    public override void StartScenario()
    {
        AddToDoneScenarios();

        DialogueManager.Instance.ShowDialogue(this);
    }
}
