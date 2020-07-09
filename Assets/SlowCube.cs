using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCube : MonoBehaviour {

    public float slowPlayer = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<ParticleSystem>().enableEmission = false;
            StartCoroutine(SlowPlayer());
        }
    }

    private IEnumerator SlowPlayer()
    {
        float originalWalkSpeed = LevelManager._instance.fpsController.m_WalkSpeed;
        float originalRunSpeed = LevelManager._instance.fpsController.m_RunSpeed;

        LevelManager._instance.fpsController.m_WalkSpeed = originalWalkSpeed / 2.0f;
        LevelManager._instance.fpsController.m_RunSpeed = originalRunSpeed / 2.0f;

        yield return new WaitForSeconds(slowPlayer);

        LevelManager._instance.fpsController.m_WalkSpeed = originalWalkSpeed;
        LevelManager._instance.fpsController.m_RunSpeed = originalRunSpeed;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}