using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    public float interactDistance = 10.0f;

    private InteractVolume currentInteractVolume = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Ray r = new Ray(transform.position, transform.forward * interactDistance);

        RaycastHit hitInfo;
        if (Physics.Raycast(r, out hitInfo, interactDistance))
        {
            //If this gameobject is interactable.

            InteractVolume interactVolume = hitInfo.collider.gameObject.GetComponent<InteractVolume>();

            if(currentInteractVolume != interactVolume)
            {
                if(currentInteractVolume != null)
                {
                    currentInteractVolume.OnInteractEnd();
                }
            }

            if (interactVolume)
            {
                Debug.DrawRay(r.origin, r.direction * interactDistance, Color.red);

                interactVolume.OnInteractBegin();
                currentInteractVolume = interactVolume;
            }
            else
            {
                Debug.DrawRay(r.origin, r.direction * interactDistance);
            }
        }

	}
}
