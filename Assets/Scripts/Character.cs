using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class Character : MonoBehaviour
{
    [SerializeField]
    protected Sprite avatar;

    [SerializeField]
    protected Sprite kingAvatar;

    [SerializeField]
    private new string name;

    List<Scenario> scenarios = new List<Scenario>();
    ScenarioElement curScenatio;
    static int scenarioIndex = 0;
    TextAsset characterScenarios;
    

    private void Start()
    {
        characterScenarios = Resources.Load<TextAsset>(name);
        List<string> scenariosText = characterScenarios.text.Split("\n").ToList();
        List<string> liens = new List<string>();
        for (int i = 0; i < scenariosText.Count; i++) 
        {
            string line = scenariosText[i].Trim();

            if (line.Length == 0 || line[0] == '/' && line[1]=='/') continue;

            if (line[0] == ';')
            {
                Scenario scenario = new Scenario(liens, this.GetType());
                scenarios.Add(scenario);
                liens.Clear();
                continue;
            }
            else
            {
                liens.Add(scenariosText[i]);
            }
        }
        if (scenarioIndex < scenarios.Count)
        {
            scenarios[scenarioIndex].Head.StartScenario();
        }
    }


}
