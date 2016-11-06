using UnityEngine;
using System.Collections;

public class GoalEvent : MonoBehaviour {

    public TextMesh title;
    public TextMesh content;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(GoalTrigger.isClear)
        {
            title.text = "抵達終點!";
            content.text = "您可以返回或重新遊戲!";
        }
	}
}
