using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {

    public float rotationSpeed = 60.0f;

    private float angleX = 0.0f;
    private float angleY = 0.0f;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        angleX += Time.deltaTime * rotationSpeed;
        angleY += Time.deltaTime * rotationSpeed;

        Quaternion rotation = Quaternion.identity;
        rotation = Quaternion.AngleAxis(angleX, Vector3.right) * rotation;
        rotation = Quaternion.AngleAxis(angleY, Vector3.up) * rotation;

        transform.rotation = rotation;


    }
}
