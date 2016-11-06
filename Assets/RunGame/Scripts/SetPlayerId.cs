using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class SetPlayerId : MonoBehaviour
{

    [Serializable]
    public class Player
    {
        public string playerId;
    }

    private const string IP = "192.168.1.251";
    private const string PORT = "3000";
    private const string url = "http://" + IP + ":" + PORT + "/users/getNewPlayerId";

    private Text playerIdText;

    // Use this for initialization
    IEnumerator Start()
    {
        playerIdText = GetComponent<Text>();
        if (!PlayerPrefs.HasKey("PlayerId"))
        {
            WWW www = new WWW(url);
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
        else
        {
            string id = PlayerPrefs.GetString("PlayerId");
            if (id == null)
                PlayerPrefs.DeleteAll();
            else
                playerIdText.text = id;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
