using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioGroups
{
    Default,
    SFX,
    Music
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager _instance;

    public List<Source> sources = new List<Source>();

    private void Awake()
    {
        if (_instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Use this for initialization
    void Start()
    {}

    public Source CreateAndPlay(string name, AudioGroups audioGroup, 
        AudioClip clip, float volume = 1.0f, bool loop = false, bool removeWhenFinished = true)
    {
        GameObject sourceObject = new GameObject();
        string groupName = Enum.GetName(typeof(AudioGroups), audioGroup);

        Source source = sourceObject.AddComponent<Source>();
        source.Init(GenerateSourceName(name), groupName, clip, volume, loop);

        source.Play();
        sources.Add(source);

        if(removeWhenFinished)
        {

        }

        return source;
    }

    Source CreateAndPlay(string name, AudioGroups audioGroup,
    AudioClip clip, float volume = 1.0f)
    {
        GameObject sourceObject = new GameObject();
        string groupName = Enum.GetName(typeof(AudioGroups), audioGroup);

        Source source = sourceObject.AddComponent<Source>();
        source.Init(GenerateSourceName(name), groupName, clip, volume, false);

        source.Play();

        sources.Add(source);

        return source;
    }

    public void RemoveSource(Source source)
    {
        sources.Remove(source);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static string GenerateSourceName(string name)
    {
        return name + "-" + DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff").GetHashCode();
    }
}
