using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
    
    private Rigidbody rb;

    public float movementSpeed = 2.0f;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {

        rb.MovePosition(transform.position + new Vector3(0.0f, 0.0f, movementSpeed /10)); 

	}
}
