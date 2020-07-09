using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerCamera : MonoBehaviour {

    [Header("Sensitivity")]
    public float pitchSensitivity = 15f;
    public float yawSensitivity = 15f;

    private float rotationY = 0.0f;
    private float rotationX = 0.0f;
    
    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
    }

	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;

        }

        rotationY += Input.GetAxis("Mouse X") * yawSensitivity;
        rotationX += Input.GetAxis("Mouse Y") * pitchSensitivity;
        Quaternion zRot = Quaternion.identity;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            zRot = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }

        Debug.DrawRay(transform.position, -hit.normal, Color.red);

        Quaternion rotation = Quaternion.identity;

        rotation = Quaternion.AngleAxis(rotationX, -Vector3.right) * rotation;
        rotation = Quaternion.AngleAxis(rotationY, Vector3.up) * rotation;

        transform.rotation = rotation;
        transform.parent.localEulerAngles = new Vector3(transform.parent.localEulerAngles.x, rotationY, transform.parent.localEulerAngles.z);
    }
}
