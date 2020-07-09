using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public struct DisplayLeaderboardRow
{
    public int place;
    public string name;
    public string time;
}

[System.Serializable]
public struct LeaderboardRow
{
    public string name;
    public string time;
}

[System.Serializable]
public class LeaderboardRowList
{
    public List<LeaderboardRow> rows;
}

public class LeaderboardRows : MonoBehaviour
{
    public Transform rowPrefab;

    private bool isDirty = false;

    // Use this for initialization
    void Start()
    {

    }
    
    private IEnumerator UpdateRowsCoroutine()
    {
        //clear out all of the rows.
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        MenuManager._instance.Loading();
        UnityWebRequest request = UnityWebRequest.Get("http://api.redwildgames.com/api/relativity/leaderboard");
        yield return request.Send();

        if (request.isNetworkError)
        {
            Debug.LogWarning("Leaderboard endpoint not accessable.");
        }
        else {

            //Correct JSON formatting because Unity's Json tool really sucks.
            string jsonBody = request.downloadHandler.text;
            jsonBody = "{ \"rows\":" + jsonBody + "}";

            //The query that returns the data from the database will order them by the time so we dont have to...
            LeaderboardRowList leaderboardRows = JsonUtility.FromJson<LeaderboardRowList>(jsonBody);

            int i = 0;
            foreach(LeaderboardRow rowItem in leaderboardRows.rows)
            {
                Vector3 position = Vector3.zero;

                GameObject row = Instantiate(rowPrefab.gameObject, position, Quaternion.identity, transform);
                LeaderboardRowDisplay rowDisplayScript = row.GetComponent<LeaderboardRowDisplay>();

                DisplayLeaderboardRow displayRow;
                displayRow.place = i + 1;
                displayRow.name = rowItem.name;
                displayRow.time = rowItem.time;

                rowDisplayScript.UpdateRow(displayRow);

                float imageHeight = rowDisplayScript.image.rectTransform.rect.height;

                position = new Vector3(0, imageHeight * i);
                rowDisplayScript.image.rectTransform.localPosition = new Vector3(0, -imageHeight * i);
                
                i++;
            }


        }

        MenuManager._instance.DoneLoading();
    }

    public void ForceRowUpdate()
    {
        isDirty = true;
    }

    void UpdateRows()
    {        
        StartCoroutine(UpdateRowsCoroutine());
    }


    // Update is called once per frame
    void Update()
    {
        if(isDirty)
        {
            UpdateRows();
            isDirty = false;
        }
    }
}
