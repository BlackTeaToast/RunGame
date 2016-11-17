using UnityEngine;
using System.Collections;

public class CollectionFinish : MonoBehaviour {
    public static bool finish;
    public TextMesh upText;
    public TextMesh downText;

	// Use this for initialization
	void Start () {
        finish = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (finish) {
            upText.text = "收集完成!!";
            downText.text = "您可以返回或重新遊戲!";
            
        }
           
	}
}
