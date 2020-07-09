using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class InteractText : MonoBehaviour {

    public static InteractText _instance;

    public readonly string defaultText = "Press {Key} to open";
    private Text textObject;

    public void ShowText(string text)
    {
        Color c = textObject.color;
        textObject.color = new Color(c.r, c.g, c.b, 1);
        textObject.text = GetInteractText(text);
    }

    /// <summary>
    ///     Returns a string where the macros have been replaced.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private string GetInteractText(string text)
    {
        if(text.Contains("{Key}"))
        {
            text = text.Replace("{Key}", Enum.GetName(typeof(KeyCode), GameManager._instance.interactKey));
        }

        return text;
    }

    public void HideText()
    {
        Color c = textObject.color;
        textObject.color = new Color(c.r, c.g, c.b, 0);
        textObject.text = GetInteractText(defaultText);
    }

    private void Start()
    {
        textObject = GetComponent<Text>();
        HideText();
    }

    // Use this for initialization
    void Awake() {
		
        if(_instance)
        {
            DestroyImmediate(this);
        }
        else
        {
            _instance = this;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
