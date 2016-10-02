using UnityEngine;
using System.Collections;

public class moveTesting : MonoBehaviour {

    // Use this for initialization
    private Rigidbody rb;//取得攝影機的Rigibody
    public Transform tf;//拿來獲取Main Camera面朝方向
    public float force;//控制移動的力道大小
    public float maxVelocity;//拿來控制能夠加速的最高速度
    public int howManySecSOneSec;//用來控制多少Sec_s等於一秒
    public GameObject cardBoardMain;
    private GvrViewer gvrViewerMain;//拿來獲得CardBoardMain 中的 CardBoard.cs ，可用來調整全域變數
    bool testingEscape = false;//測試用，利用手機的返回鍵來開關VR鏡片變形處理
    int bottomNumber = 10;//顯示在底部的時間
    bool notSetText = false;//不調整文字
    bool fall = false;//不甚掉落
    public float fallY;//觸發掉落的Y座標
        
    //文字
    public GameObject upText;//上方文字
    public TextMesh textY;//上方文字
    public GameObject bottomTime;//顯示在下方的提示時間數字
    public TextMesh bottomTimeText;

    //CardBoard面對的方向 (令Y軸為0，取單位向量)
    Vector3 frontMove;

    //加速度比較用
    float xOld;
    float yOld;
    float zOld;

    //紀錄y軸變量
    float ySave=0;
    float[] yTemp = new float[15];
    //暫存要拿來平均的y軸變量，的index
    int yTempIndex = 0;

    //計時用，每一秒timer_f+1 且轉為int存入timer_i
    float old_timer=0;
    float timer_f=0;
    int timer_i=0;
    int min=0, sec=0, hour=0,sec_s=0;

    void Start () {

        //取得cardBoard的Script
        gvrViewerMain = cardBoardMain.GetComponent<GvrViewer>() ;
        //取得下方顯示數字時間的TextMesh Component
        bottomTimeText = bottomTime.GetComponent<TextMesh>();
        
        rb = GetComponent<Rigidbody>();
        
        yOld = Input.acceleration.y;
        
    }

    void LateUpdate()
    {
        GvrViewer.Instance.UpdateState();
        if (GvrViewer.Instance.BackButtonPressed)
        {
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update() {
        //新的加速度與舊的加速度取差值
        float dy = Input.acceleration.y - yOld;
        
        //取正值
        if (dy < 0)
            dy = -dy;
        
        //時間===================================
        //每過一秒計時器加一
        timer_f += Time.deltaTime;
        timer_i = (int)timer_f;
        //如果過了60則歸零
        if (timer_i == 60)
        {
            timer_f = 0;
            timer_i = 0;
        }
        //每過了一毫秒
        if (old_timer != timer_f) {
            old_timer = timer_f;
            sec_s++;
            

            //每過了一秒
            if (sec_s == howManySecSOneSec)
            {

                sec_s = 0;
                sec++;
                //每一秒，提示數字遞減
                if (sec < 16 || fall)
                {
                    if (bottomNumber > 0)
                        bottomNumber--;

                    if (sec == 11 && !fall)
                        bottomNumber = 5;
                }

                //過了一秒後如果剛好是21秒，則取晃動平均，用此平均當作晃動基準
                else if (sec == 16)
                {
                    saveYValue();
                }
                //每過了一分鐘
                if (sec == 60)
                {
                    sec = 0;
                    min++;
                }
                //每過了一小時
                if (min == 60)
                {
                    min = 0;
                    hour++;
                }
            }

            //10秒後紀錄晃動>>>>>>
            if (sec > 10 && yTempIndex <= 14)
            {
                //每15毫秒都記錄一次
                if (sec_s == 5 || sec_s == 20 || sec_s == 35)
                    yTemp[yTempIndex++] = dy;
            }

            if (testingEscape == true)
            {//測試VR啟用變形
                textY.text = "測試中...";
            }
            //文字顯示沒有關掉時顯示文字
            else if (notSetText == false) {
                if (fall==true) {
                    if (bottomNumber == 0)
                        justReset();
                    showText("掉落中...");
                }

                else if (sec > 10 && sec <= 15 && min == 0 && hour == 0)
                {
                    //顯示文字
                    showText("紀錄晃動幅度中..");
                }
                else if (sec <= 10)
                {
                    //顯示文字
                    showText("準備紀錄晃動幅度");

                }

                else {
                    //關掉所有文字顯示
                    turnAllText(false);
                    notSetText = true;
                }
            }
            
        }
               
        //時間===================================
        

        //過了15秒之後，如果比測定的平均還要多則移動
        if (hour>=1 || min>=1 || sec>15 || Input.GetKey("space"))
            if(dy >= ySave && ySave!=0 || Input.GetKey("space"))
                moveTest();

        
        yOld = Input.acceleration.y;


        //測試用，利用手機的返回鍵來開關VR鏡片變形處理
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (testingEscape == false)
            {
                //gvrViewerMain.DistortionCorrection = false;
                testingEscape = true;
            }

            else {
                //切換回來的時候做初始化，方便測試用
                //gvrViewerMain.DistortionCorrection = true;
                testingEscape = false;
                //重置
                resetGame(10);
                                
            }

        }

        
        //掉落的話
        //if (gvrViewerMain.transform.position.y <= fallY && fall==false) {
        //    falling();
        //}
        

    }

    void moveTest() {
        //若不超過最大速限，則給予推力
        if (rb.velocity.y <= maxVelocity) {
            frontMove = tf.forward;
            frontMove.y = 0;//令y軸方向向量歸零
            frontMove.Normalize();//取得單位向量
            rb.AddForce(frontMove * force);
        }
            
    }

    //把平均記錄起來
    void saveYValue() {
        float sum=0;
        for (int i = 0; i < 15; i++) {
            sum += yTemp[i];
        }
        ySave = sum / 15;

    }
    //關掉或打開文字
    void turnAllText(bool temp) {
        upText.SetActive(temp);
        bottomTime.SetActive(temp);
    }

    //重置(下方數字設置)
    void resetGame(int number) {
        hour = 0;
        min = 0;
        sec = 0;
        sec_s = 0;
        turnAllText(true);
        notSetText = false;
        bottomNumber = number;
        cardBoardMain.GetComponent<Transform>().position = new Vector3((float)-0.99, (float)1.27, (float)-275.4);
        fall = false;
    }

    //重置(不去重新設定Y軸晃動變量)
    void justReset() {
        //不調整文字
        notSetText = true;
        //關掉文字
        turnAllText(false);
        cardBoardMain.GetComponent<Transform>().position = new Vector3((float)-0.99, (float)1.27, (float)-275.4);
        fall = false;
    }

    //顯示文字 配數字
    void showText(string s) {
        //int利用toString 轉型
        textY.text = s;
        bottomTimeText.text = bottomNumber.ToString();
    }

    //觸發掉落
    void falling() {
        turnAllText(true);
        notSetText = false;
        fall = true;
        bottomNumber = 5;

    }
   
}
