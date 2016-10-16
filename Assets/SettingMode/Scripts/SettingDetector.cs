using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingDetector : MonoBehaviour {

    private const float Y_MOVE_DEFAULT = 0.15f;    //預設值
    private float yMove;    //震動觸發移動的值
    private bool isStartDetect = false;
    private bool isDetecting = false;
    private float timeLeft;
    private ArrayList yTemp;
    private float yOld = 0;

    public GameObject Menu;
    public Text CurrentSettingText;
    public TextMesh TimeTip;
    public TextMesh Title;

                            // Use this for initialization
    void Start () {

        yTemp = new ArrayList();

        yMove = PlayerPrefs.GetFloat("Y_MOVE", Y_MOVE_DEFAULT);  //取得震動y值觸發移動
        CurrentSettingText.text = "目前設定值：" + yMove;
    }
	
	// Update is called once per frame
	void Update () {

        float dy = Input.acceleration.y - yOld;
        
        if (isStartDetect)
        {
            timeLeft -= Time.deltaTime;
            Title.text = "準備開始偵測";
            TimeTip.text = ((int)timeLeft).ToString();
            if(timeLeft<=0)
            {
                isStartDetect = false;
                isDetecting = true;
                timeLeft = 10f;
            }
        }
        else if(isDetecting)
        {
            //取正值
            if (dy < 0)
                dy = -dy;

            timeLeft -= Time.deltaTime;
            Title.text = "偵測中";
            TimeTip.text = ((int)timeLeft).ToString();
            yTemp.Add(dy);
            if (timeLeft <= 0)
            {
                float sum = 0;
                foreach(float y in yTemp)
                {
                    sum += y;
                }
                PlayerPrefs.SetFloat("Y_MOVE", sum / yTemp.Count);
                CurrentSettingText.text = "目前設定值：" + sum / yTemp.Count;
                Title.text = "";
                TimeTip.text = "";
                Menu.SetActive(true);  //顯示選單
                isDetecting = false;
                yTemp.Clear();
            }
        }

        yOld = Input.acceleration.y;

    }

    public void StartDetect()
    {
        Menu.SetActive(false);  //隱藏選單
        timeLeft = 10f;
        isStartDetect = true;
    }
}
