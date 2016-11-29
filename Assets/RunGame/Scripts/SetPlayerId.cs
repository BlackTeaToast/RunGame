using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text;

public class SetPlayerId : MonoBehaviour
{

    [Serializable]
    public class Player
    {
        public string playerId;
    }

    [Serializable]
    public class PlayerIdCheck
    {
        public bool isValid;
    }

    private const string IP = "140.134.26.86";
    private const string PORT = "3000";
    private const string getNewPlayerIdUrl = "http://" + IP + ":" + PORT + "/users/getNewPlayerId";
    private const string checkPlayerIdUrl = "http://" + IP + ":" + PORT + "/users/checkPlayerId";

    private Text playerIdText;

    // Use this for initialization
    void Start()
    {
        playerIdText = GetComponent<Text>();
        if (!PlayerPrefs.HasKey("PlayerId"))
        {
            StartCoroutine(getNewPlayerId());
        }
        else
        {
            string id = PlayerPrefs.GetString("PlayerId");
            if (id == null)
            {
                PlayerPrefs.DeleteAll();
                StartCoroutine(getNewPlayerId());
            }
            else
            {
                StartCoroutine(checkId(id));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator getNewPlayerId()
    {
        WWW www = new WWW(getNewPlayerIdUrl);
        yield return www;
        try
        {
            if (www.isDone)
            {
                Player player = JsonUtility.FromJson<Player>(www.text);
                if (player.playerId != null)
                {
                    PlayerPrefs.SetString("PlayerId", player.playerId);
                    playerIdText.text = player.playerId;
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message, gameObject);
        }
    }

    IEnumerator checkId(string id)
    {
        Dictionary<string, string> postHeader = new Dictionary<string, string>();
        Player player = new Player();
        player.playerId = id;
        string jsonString = JsonUtility.ToJson(player);
        postHeader.Add("Content-Type", "application/json");
        postHeader.Add("Content-Length", jsonString.Length.ToString());
        WWW www = new WWW(checkPlayerIdUrl, Encoding.UTF8.GetBytes(jsonString), postHeader);
        yield return www;
        try
        {
            if (www.isDone)
            {
                PlayerIdCheck playerIdCheck = JsonUtility.FromJson<PlayerIdCheck>(www.text);
                if (playerIdCheck.isValid == false)
                {
                    StartCoroutine(getNewPlayerId());
                } else
                {
                    playerIdText.text = id;
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message, gameObject);
        }
    }

}
