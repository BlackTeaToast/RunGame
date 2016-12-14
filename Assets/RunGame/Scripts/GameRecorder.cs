using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;

public class GameRecorder : MonoBehaviour
{

    [Serializable]
    public class GameData
    {
        public GameData(float avgY)
        {
            this.avgY = avgY;
        }
        public float avgY;
    }

    [Serializable]
    public class GameHistory
    {
        public string playerId;
        public string stageName;
        public float gameTime;
        public float frequency;
        public int[] gameData;
    }

    private const float Y_MOVE_DEFAULT = 0.15f;    //預設值
    private float yMove;    //震動觸發移動的值
    private float yOld = 0;
    private float timeLeft = 1.0f;
    private int avg = 0;
    private int count = 0;
    private ArrayList gameDataList;
    private bool isUpload = false;

    private const string IP = "140.134.26.86";
    private const string PORT = "3000";
    private const string URL = "http://" + IP + ":" + PORT + "/upload/uploadGameHistory";

    public string StageName = "Default";
    public float Frequency = 1.0f;

    // Use this for initialization
    void Start()
    {
        yMove = PlayerPrefs.GetFloat("Y_MOVE", Y_MOVE_DEFAULT);  //取得震動y值觸發移動
        gameDataList = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalTrigger.isClear && !isUpload)
        {
            if (count == 0)
            {
                gameDataList.Add(0);
            }
            else
            {
                avg /= count;
                gameDataList.Add(avg);
            }

            GameHistory gameHistory = new GameHistory();
            gameHistory.playerId = PlayerPrefs.GetString("PlayerId");
            gameHistory.stageName = StageName;
            gameHistory.gameTime = GameTimer.time;
            gameHistory.frequency = Frequency;
            gameHistory.gameData = (int[])gameDataList.ToArray(typeof(int));
            isUpload = true;
            StartCoroutine(upload(gameHistory));

        }
        else
        {
            float dy = Mathf.Abs(Input.acceleration.y - yOld);

            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                if (count == 0)
                {
                    gameDataList.Add(0);
                }
                else
                {
                    avg /= count;
                    gameDataList.Add(avg);
                }
                timeLeft = 1.0f;
                avg = 0;
                count = 0;
            }
            else
            {
                if (dy > yMove)
                {
                    avg += (int)(dy*100);
                    count++;
                }
            }

            yOld = Input.acceleration.y;
        }
    }

    IEnumerator upload(GameHistory gameHistory)
    {
        Dictionary<string, string> postHeader = new Dictionary<string, string>();
        string jsonString = JsonUtility.ToJson(gameHistory);
        Debug.Log(jsonString);
        postHeader.Add("Content-Type", "application/json");
        postHeader.Add("Content-Length", Encoding.UTF8.GetBytes(jsonString).Length.ToString());
        WWW www2 = new WWW(URL, Encoding.UTF8.GetBytes(jsonString), postHeader);
        yield return www2;
        try
        {
            if (string.IsNullOrEmpty(www2.error))
                Debug.Log(www2.text);  //text of success
            else
                Debug.Log(www2.error);  //error
        }
        catch (Exception e)
        {
            Debug.Log(e.Message, gameObject);
        }

    }

}
