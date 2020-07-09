using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour {

    public delegate void MenuStateEvent();

    public MenuStateEvent onShow;
    public MenuStateEvent onHide;

    public bool showOnStart = false;

    public string menuName = string.Empty;

    protected abstract void Init();

    public void OnMenuStateChange(MenuState menuState)
    {
        switch (menuState)
        {
            case MenuState.Shown:
                gameObject.SetActive(true);
                onShow();
                break;
            case MenuState.Hidden:
                gameObject.SetActive(false);
                onHide();
                break;

            default:
                break;
        }
    }

    protected abstract void Show();

    protected abstract void Hide();

    public void InitMenu()
    {
        onShow += Show;
        onHide += Hide;

        if (menuName == string.Empty)
        {
            menuName = gameObject.name;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
