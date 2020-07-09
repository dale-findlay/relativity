using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public static Timer _instance;

    public float time = 0.0f;

    public bool active = true;

	// Use this for initialization
	void Awake() {
        if(_instance)
        {
            Debug.LogWarning("There can only be one timer in the level.");
        }
        else
        {

        }
        _instance = this;

	}

    public void Stop()
    {
        active = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(active)
        {
            time += Time.deltaTime;
        }
    }
}
