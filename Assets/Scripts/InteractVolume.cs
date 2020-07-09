using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class InteractVolume : MonoBehaviour
{

    public Interactable interactable;

    public bool currentlyActive = false;

    public void OnInteractBegin()
    {

        if (interactable)
        {
            if (!currentlyActive)
            {
                interactable.ShowInteractMessage();
                currentlyActive = true;
            }

            interactable.InvokeOnInteract();
        }
        else
        {
            Debug.LogError("Interactable not set one Interact Volume in parent: " + transform.parent.gameObject.name);
        }
    }

    public void OnInteractEnd()
    {
        if (interactable)
        {
            if (currentlyActive)
            {
                interactable.HideInteractMessage();
                currentlyActive = false;
            }

            interactable.InvokeOnInteractEnd();

        }
        else
        {
            Debug.LogError("Interactable not set one Interact Volume in parent: " + transform.parent.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
