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
        resetPosition = transform.position;
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
                gvrViewer.transform.position = resetPosition;
                isFalling = false;
                Title.text = "";
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
