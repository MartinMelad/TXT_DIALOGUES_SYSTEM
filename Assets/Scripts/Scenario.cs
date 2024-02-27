using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

/*
 * { New Branch
 * } End Branch
 * 0 Set Character Name
 * 1 Character Dialogue
 * 2 Question
 * 3 Choice Title
 * 4 Scenario Action
 */

public class Scenario
{
    ScenarioElement head = null;
    ScenarioElement cur = null;
    ScenarioElement lst = null;

    Stack<ScenarioElement> stack = new Stack<ScenarioElement>();

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
                stack.Push(lst);
                continue;
            }
            else if (line[0] == '}') 
            {
                lst = stack.Pop();
                continue;
            }
            else if (line[0] == '0')
            {
                this.characterName = line.Substring(2);
            }
            else if (line[0] == '1') 
            {
                cur = new Dialogue(line.Substring(2));
            }
            else if (line[0] == '2')
            {
                cur = new Question(line.Substring(2));
            }
            else if (line[0] == '3')
            {
                if (cur is Question)
                {
                    (cur as Question).AddChoice(line.Substring(2));
                }
            }
            else if (line[0] == '4')
            {
                string[] strings = line.Split(' ');
                string name = strings[1];

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

            if (lst == null) head = cur;
            else if (lst != cur)
            {
                lst.AddScenarioElement(cur);
            }
            lst = cur;
        }
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
