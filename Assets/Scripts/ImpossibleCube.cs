using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ParticleSystem), typeof(MeshRenderer))]
public class ImpossibleCube : MonoBehaviour
{
    public AudioClip pickupSound;

    private Coroutine collectRoutine = null;

    private IEnumerator Collect()
    {
        GetComponent<MeshRenderer>().enabled = false;

#pragma warning disable CS0618 // Type or member is obsolete
        GetComponent<ParticleSystem>().enableEmission = false;
#pragma warning restore CS0618 // Type or member is obsolete

        Source source = AudioManager._instance.CreateAndPlay("collect", AudioGroups.SFX, pickupSound);

        yield return new WaitForSeconds(pickupSound.length);

        AudioManager._instance.RemoveSource(source);

        Destroy(source.gameObject);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collectRoutine == null)
        {
            GameManager._instance.cubeCountThisRound += 1;
            collectRoutine = StartCoroutine(Collect());
        }
    }

    // Use this for initialization
    void Start()
    {
        GetComponent<ParticleSystem>().enableEmission = false;
    }
}
