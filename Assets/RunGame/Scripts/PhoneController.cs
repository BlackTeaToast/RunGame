﻿using UnityEngine;
using System.Collections;

public class PhoneController : MonoBehaviour {

    private const float Y_MOVE_DEFAULT = (float)1.0;
    private float yMove;    //震動觸發移動的值

	// Use this for initialization
	void Start () {
        yMove = PlayerPrefs.GetFloat("y", Y_MOVE_DEFAULT);  //取得震動y值觸發移動
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
