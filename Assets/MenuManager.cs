using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum MenuState
{
    Shown,
    Hidden
}

public class MenuManager : MonoBehaviour {
    
    public static MenuManager _instance;
    public GameObject loading;

    public List<Menu> menus = new List<Menu>();

	// Use this for initialization
	void Awake () {
		
        if(_instance)
        {
            Debug.LogWarning("There can be only 1 MenuManager Instance.");
        }
        else
        {
            _instance = this;
        }

	}

    public static void SetMenuState(MenuState state, string menuName)
    {
        _instance.ChangeMenuState(state, menuName);
    }

    public void ChangeMenuState(MenuState state, string menuName)
    {
        foreach(Menu menu in menus)
        {
            if(menu.menuName == menuName)
            {
                menu.OnMenuStateChange(state);
            }
        }
    }

    public void Loading()
    {
        loading.SetActive(true);
    }

    public void DoneLoading()
    {
        loading.SetActive(false);
    }


    private void Start()
    {
        foreach(Menu menu in menus)
        {
            menu.InitMenu();

            if(menu.showOnStart)
            {
                menu.OnMenuStateChange(MenuState.Shown);
            }
            else
            {
                menu.OnMenuStateChange(MenuState.Hidden);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
