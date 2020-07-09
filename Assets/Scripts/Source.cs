using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{
    public int id;
    public string sourceName;
    public string sourceGroup;
    public AudioSource source;

    public void Init(string name, string group, AudioClip clip, float volume, bool loop)
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.loop = loop;

        sourceName = name;
        sourceGroup = group;
    }

    public void Play()
    {
        source.Play();
    }

    private IEnumerator FadeOutAudio(float seconds)
    {
        float original = source.volume;

        for (float t = 0.0f; t <= seconds; t += Time.deltaTime)
        {
            source.volume = Mathf.Lerp(original, 0, t / seconds);
            yield return null;
        }

        source.volume = 0;

        AudioManager._instance.RemoveSource(this);
        Destroy(gameObject);
    }

    public void FadeOut(float seconds)
    {
        StartCoroutine(FadeOutAudio(seconds));
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
