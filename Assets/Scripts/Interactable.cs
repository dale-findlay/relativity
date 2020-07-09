using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour {

    public string interactText = "Press {Key} to enter";

    public delegate void OnEvent();
    public event OnEvent onInteract;
    public event OnEvent onInteractEnd;

    public KeyCode interactKey = KeyCode.E;
    public bool canShowText = false;
    public InteractVolume interactVolume;

    public UnityEvent onInteractUnityEvent;
    public UnityEvent onInteractEndUnityEvent;

    protected void Start()
    {
        if(interactVolume)
        {
            interactVolume.interactable = this;
        }
    }

    void OnInteractUnityEvent()
    {
        onInteractUnityEvent.Invoke();
    }

    void OnInteractEndUnityEvent()
    {
        onInteractEndUnityEvent.Invoke();
    }

    public Interactable()
    {
        onInteract += OnInteract;

        //Add exposed unity event.
        onInteract += OnInteractUnityEvent;


        onInteractEnd += OnInteractEnd;
        onInteractEnd += OnInteractEndUnityEvent;
    }

    /// <summary>
    /// Shows the bound interact message.
    /// Automatically called by onInteractBegin event.
    /// </summary>
    public void ShowInteractMessage()
    {
        if (canShowText)
        {
           InteractText._instance.ShowText(interactText);
        }
    }

    public void InvokeOnInteractEnd()
    {
        onInteractEnd();
    }

    /// <summary>
    /// Hides the bound interact message.
    /// Automatically called by onInteractEnd event.
    /// </summary>
    public void HideInteractMessage()
    {
        InteractText._instance.HideText();
    }

    public void InvokeOnInteract()
    {
        if(Input.GetKeyDown(GameManager._instance.interactKey))
        {
            onInteract();
        }

        if(Input.GetKeyUp(GameManager._instance.interactKey))
        {
            onInteractEnd();
        }

    }

    protected abstract void OnInteract();
    protected abstract void OnInteractEnd();

    // Update is called once per frame
    void Update () {

        if(interactVolume == null)
        {
            Debug.LogWarning("no interact volume on object: " + gameObject.name);
        }		
	}
}
