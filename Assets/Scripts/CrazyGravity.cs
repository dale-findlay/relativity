using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(FirstPersonController))]
public class CrazyGravity : MonoBehaviour {

    public static CrazyGravity _instance;

    private float gravityTime;
    private bool gravityEnabled = false;

    float originalGravityMultiplier = 2.0f;
    void Awake()
    {
        if(_instance)
        {
            DestroyImmediate(this);
        }

        _instance = this;
    }

    public void Degravity()
    {
        FirstPersonController fpsController = GetComponent<FirstPersonController>();
        fpsController.m_GravityMultiplier = originalGravityMultiplier;
    }


    public IEnumerator GravityTimeLast(float timeLast)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        FirstPersonController fpsController = GetComponent<FirstPersonController>();

        if (rb != null)
        {
            rb.useGravity = false;
        }

        originalGravityMultiplier = fpsController.m_GravityMultiplier;
        Debug.Log(originalGravityMultiplier);

        fpsController.m_GravityMultiplier = 0.5f;

        yield return new WaitForSeconds(timeLast);

        fpsController.m_GravityMultiplier = originalGravityMultiplier;
    }

    public void ActivateGravity(float timeLast)
    {
        gravityEnabled = true;
        gravityTime = timeLast;
    }
    
    // Use this for initialization
	void Start () {        
    }
	
	// Update is called once per frame
	void Update () {

        if(gravityEnabled)
        {
            StartCoroutine(GravityTimeLast(gravityTime));

            gravityEnabled = false;
        }


    }
}
