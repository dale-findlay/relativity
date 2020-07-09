using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuResume : MonoBehaviour {

    public void OnClick()
    {
        MenuManager.SetMenuState(MenuState.Hidden, "PauseMenu");
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
