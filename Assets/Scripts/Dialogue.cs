using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : BaseScenario
{

    Sprite avatar;
    string characterName;
    string message;

    public Sprite Avatar { get { return avatar; } set { avatar = value; } }
    public string CharacterName { get { return characterName; } set { characterName = value; } }
    public string Message { get { return message; } set { message = value; } }

    protected override void StartScenario()
    {
        
    }
}
