using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class GameOptions
{
    public int m_inverseness;

    public int Inverseness
    {
        get
        {
            return 1;
        }

        set
        {
            if(value == 1 || value == -1)
            {
                m_inverseness = value;
            }
        }
    }
}
