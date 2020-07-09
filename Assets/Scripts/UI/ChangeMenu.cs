using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMenu : MonoBehaviour
{
    public List<GameObject> m_Menus;

    private void Start()
    {
        int i = 0;
        foreach(GameObject menu in m_Menus)
        {
            if (i != 0)
            {
                menu.SetActive(false);
            }
            i++;
        }
    }

    public void showMenu(string menuToShow)
    {
        GameManager._instance.SaveSettings();

        foreach(GameObject menu in m_Menus)
        {
            if(menu.name == menuToShow)
            {
                menu.SetActive(true);
            }
            else
            {
                menu.SetActive(false);
            }
        }
    }

}
