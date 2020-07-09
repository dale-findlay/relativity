using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterSucker : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public bool suck;
    Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb = other.gameObject.GetComponent<Rigidbody>();

            suck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb = null;

            suck = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
        if(suck)
        {

        }

	}
}
