using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : Interactable {

    public AnimationClip doorOpen;
    public AnimationClip doorClosed;


    private float playSpeed = 1.0f;
    

    protected override void OnInteract()
    {
        if (!GetComponent<Animation>().isPlaying)
        {
            canShowText = false;
            HideInteractMessage();
            if (playSpeed == 1.0f)
            {
                GetComponent<Animation>().Play("open"); 
                playSpeed = -1.0f;
            }
            else
            {
                GetComponent<Animation>().Play("closed");
                playSpeed = 1.0f;
            }

        }
    }

    protected override void OnInteractEnd()
    {
        canShowText = true;
    }

    // Use this for initialization
    new void Start()
    {
        GetComponent<Animation>().AddClip(doorOpen, "open");
        GetComponent<Animation>().AddClip(doorClosed, "closed");

        base.Start();
    }
}
