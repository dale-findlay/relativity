using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardRowDisplay : MonoBehaviour {

    public Image image;

    public Text number;
    public Text userName;
    public Text time;

    public void Start()
    {
        image = GetComponent<Image>();
    }

    public void UpdateRow(DisplayLeaderboardRow rowData)
    {
        number.text = rowData.place.ToString();
        userName.text = rowData.name;
        time.text = rowData.time.ToString() + "s";
    }
}
