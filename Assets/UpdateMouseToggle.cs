using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class UpdateMouseToggle : MonoBehaviour {

    private Toggle toggle;

	// Use this for initialization
	void Start () {

        toggle = GetComponent<Toggle>();
        toggle.isOn = GameManager._instance.m_GameOptions.Inverseness == -1 ? true : false;

    }

    void UpdateToggle()
    {
    }

	// Update is called once per frame
	void Update () {
        
    }
}
