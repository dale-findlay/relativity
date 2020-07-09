using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class LevelManager : MonoBehaviour
{
    //public List<Object> m_Levels; //stores levels being used in the game.
    public static LevelManager _instance;

    public FirstPersonController fpsController;
    
    /// <summary>
    /// called on awake, we're using it to set this up as a singleton
    /// </summary>
    private void Awake()
    {

        if (_instance)
        {
            DestroyImmediate(this);
        }
        else
        {
            _instance = this;
        }

    }



    /// <summary>
    /// Load level(scene) with name targetLevel
    /// </summary>
    /// <param name="targetLevel">the scene you wish to go to</param>
	public void GoToLevel(string targetLevel)
    {
        SceneManager.LoadScene(targetLevel);
    }

    /// <summary>
    /// Tells the program to exit
    /// </summary>
    public void exitGame()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().SaveSettings();
        Application.Quit();
    }

    
}
