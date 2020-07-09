using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameManager : MonoBehaviour
{
    public int cubeCountThisRound = 0;
    public int cubeCount = 0;
    public static GameManager _instance;

    //game options
    public GameOptions m_GameOptions;

    public KeyCode interactKey = KeyCode.E;

    public Timer timer;

    private void Awake()
    {
        if (_instance)
        {
            DestroyImmediate(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }

    }

    void UpdateCubeCountLocal()
    {
        if (cubeCount == 0)
        {
            cubeCount = PlayerPrefs.GetInt("cubeCount");
        }
    }

    public void OnSceneLoad(Scene scene, LoadSceneMode loadSceneMode)
    {
        UpdateCubeCountLocal();

        cubeCount += cubeCountThisRound;
        PlayerPrefs.SetInt("cubeCount", cubeCount);
        cubeCountThisRound = 0;

        PlayerPrefs.Save();

    }

    public IEnumerator ShowLoadingIcon(float seconds)
    {
        MenuManager._instance.Loading();
        yield return new WaitForSeconds(seconds);
        MenuManager._instance.DoneLoading();
    }

    /// <summary>
    /// Saves our GameOptions to file.
    /// </summary>
    /// <returns></returns>
    public bool SaveSettings()
    {
        StartCoroutine(ShowLoadingIcon(0.5f));
        string settings = JsonUtility.ToJson(m_GameOptions);
        
        PlayerPrefs.SetString("settings", settings);
        PlayerPrefs.Save();

        //XmlSerializer serializer = new XmlSerializer(typeof(GameOptions));
        //StreamWriter streamWriter = new StreamWriter("settings.xml");
        //serializer.Serialize(streamWriter, m_GameOptions);
        //streamWriter.Close();
        return true;
    }

    /// <summary>
    /// Loads the GameOptions from a file.
    /// </summary>
    public void LoadSettings()
    {
        StartCoroutine(ShowLoadingIcon(0.2f));
        m_GameOptions = JsonUtility.FromJson<GameOptions>(PlayerPrefs.GetString("settings"));
    }

    /// <summary>
    /// toggles the invert y-axis mouse option
    /// </summary>
    public void UpdateToogleInverseness(Toggle toggle)
    {
        m_GameOptions.Inverseness = toggle.isOn ? -1 : 1;
    }

    public int GetInversity()
    {
        return m_GameOptions.Inverseness;
    }

    // Use this for initialization
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoad;

        UpdateCubeCountLocal();

        if (m_GameOptions == null)
        {
            m_GameOptions = new GameOptions();
            m_GameOptions.Inverseness = 1;
        }
        LoadSettings();
    }

    // Update is called once per frame
    void Update()
    {

    }
}