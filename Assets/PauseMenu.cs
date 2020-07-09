using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Menu {
    
    protected override void Init()
    {
        
    }

    protected override void Show()
    {
        Timer._instance.active = false;
        LevelManager._instance.fpsController.m_MouseLook.SetCursorLock(false);
        LevelManager._instance.fpsController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    protected override void Hide()
    {
        Timer._instance.active = true;
        LevelManager._instance.fpsController.m_MouseLook.SetCursorLock(true);
        LevelManager._instance.fpsController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
