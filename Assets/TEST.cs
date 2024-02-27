using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    List<string> txt = new List<string>()
    {
        "1 51515",
        "1 555555",
        "4 _7a7a",
    };

    public static void _7a7a()
    {
        Debug.Log("HI IAM 7A7A");
    }

    // Start is called before the first frame update
    void Start()
    {
        Scenario scenario = new Scenario(txt, this.GetType());
        scenario.Waddy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
