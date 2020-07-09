using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Degravity : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            CrazyGravity._instance.Degravity();
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
