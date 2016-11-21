using UnityEngine;
using System.Collections;

public class FallingDetector : MonoBehaviour {

    private float yOld = 0;
    private bool isFalling = false;
    private GvrViewer gvrViewer;
    private float timeLeft;

    public Transform Head;
    public float fallY = 0;
    public TextMesh Title;
    public TextMesh TimeTip;
    public  Vector3 resetPosition;

	// Use this for initialization
	void Start () {
        
        gvrViewer = GetComponent<GvrViewer>();
        resetPosition = transform.position;//抓取一開始的位置並設為為重生點
	}
	
	// Update is called once per frame
	void Update () {

        float dy = Input.acceleration.y - yOld;

        if(isFalling)
        {
            timeLeft -= Time.deltaTime;
            Title.text = "掉落中...";
            TimeTip.text = ((int)timeLeft).ToString();
            if (timeLeft <= 0)
            {
                gvrViewer.transform.position = resetPosition;//將GvrMain搬回重生點
                isFalling = false;
                Title.text = "";//將標題與副標題清空
                TimeTip.text = "";
            }
        }

        if ((gvrViewer.transform.position.y < fallY)&&(!isFalling))
        {
            timeLeft = 5f;
            isFalling = true;
        }

        yOld = Input.acceleration.y;
    }
}
