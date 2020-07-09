using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMenu : Menu {

    public LeaderboardRows leaderboardRows;

    protected override void Init()
    {
        
    }

    protected override void Show()
    {
        Timer._instance.active = false;
        LevelManager._instance.fpsController.m_MouseLook.SetCursorLock(false);
        LevelManager._instance.fpsController.enabled = false;
        leaderboardRows.ForceRowUpdate();
        Cursor.lockState = CursorLockMode.None;
    }

    protected override void Hide()
    {

    }
}
