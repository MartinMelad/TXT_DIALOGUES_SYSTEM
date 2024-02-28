using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/*
 * { New Branch
 * } End Branch
 * 0 Set Character Name
 * 1 Character Dialogue
 * 2 Question
 * 3 Choice Title
 * # Set Scenario Element Code Name
 * 4 Scenario Action 
 * /*\ Special Functions:
 * 4 Connect (string code1, string code2)
 * 4 Clear (string code)
 * ; End Scenario
 * // comment 
 */

public class Scenario
{
    ScenarioElement head = null;
    ScenarioElement cur = null;
    ScenarioElement lst = null;

    Stack<ScenarioElement> stack = new Stack<ScenarioElement>();
    Dictionary<string, ScenarioElement> codeToScenarioElement = new Dictionary<string, ScenarioElement>();
    List<Tuple<string, string>> toConnectList = 
        new List<Tuple<string, string>>();

    // To Disconnect the Scenario after }
    bool isAfterClose = false;

    string characterName;
    Type classType;

    public ScenarioElement Head {  get { return head; } }


    public Scenario(List<string> lines, Type _classType)
    {
        this.classType = _classType;

        for (int i = 0; i < lines.Count; i++)
        {
            string line = lines[i];
            line = line.Trim();

            if (line[0] == '{')
            {
                isAfterClose = false;
                stack.Push(lst);
                continue;
            }
            else if (line[0] == '}') 
            {
                isAfterClose = true;
                lst = stack.Pop();
                continue;
            }
            else if (line[0] == '0')
            {
                this.characterName = line.Substring(2);
                continue;
            }
            else if (line[0] == '1') 
            {
                cur = new Dialogue(characterName,line.Substring(2));
            }
            else if (line[0] == '2')
            {
                cur = new Question(line.Substring(2));
            }
            else if (line[0] == '3')
            {
                if (lst is Question)
                {
                    (lst as Question).AddChoice(line.Substring(2));
                }
                continue;
            }
            else if (line[0] == '4')
            {
                string[] strings = line.Split(' ');
                string name = strings[1];

                if (name == "Connect" && strings.Length > 3)
                {
                    toConnectList.Add(new Tuple<string, string>(strings[2], strings[3]));
                    cur = new ScenarioAction(null, null);
                }
                else if (name == "Clear" && strings.Length > 2)
                {
                    codeToScenarioElement[strings[2]].NextElements.Clear();
                    cur = new ScenarioAction(null, null);
                }
                else
                {
                    MethodInfo theAction = classType.GetMethod(name);

                    if (strings.Length > 2)
                    {
                        cur = new ScenarioAction(theAction, int.Parse(strings[2]), classType);
                    }
                    else
                    {
                        cur = new ScenarioAction(theAction, classType);
                    }
                }


            }
            else if (line[0] == '#')
            {
                lst.CodeName = line.Substring(2);
                codeToScenarioElement.Add(lst.CodeName, lst);
                continue;
            }
            else { continue; }

            if (lst == null) head = lst = cur;
            if (lst != cur)
            {
                if (isAfterClose ==  false)
                {
                    lst.AddScenarioElement(cur);
                }
                else { isAfterClose = false; }
                lst = cur;
            }
        }

        ConnectTheToConnectList();
    }

    private void ConnectTheToConnectList()
    {
        foreach (var T in toConnectList)
        {
            ScenarioElement e1 = codeToScenarioElement[T.Item1];
            ScenarioElement e2 = codeToScenarioElement[T.Item2];
            if (e1.NextElements.Contains(e2) == false) e1.AddScenarioElement(e2);
        }
        toConnectList.Clear();
    }

    private void Go(ScenarioElement p)
    {
        p.StartScenario();
        foreach (var ch in p.NextElements)
        {
            if (ch != p)
            {
                Go(ch);
            }
        }
        Debug.Log("END");
    }

    public void Waddy()
    {
        ScenarioElement pointer = head;
        Go(pointer);
    }
 
}
