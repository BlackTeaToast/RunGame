using UnityEngine;
using System.Collections;

public class KeyBoardController : MonoBehaviour {

    private Rigidbody rb;
    private Transform tf;
    private Vector3 frontMove;

    public float force;//控制移動的力道大小
    

    // Use this for initialization
    void Start () {
	    rb = GetComponent<Rigidbody>();
        tf = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //方向鍵 上
	    if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            frontMove = tf.forward;
            frontMove.y = 0;                //令y軸方向向量歸零
            frontMove.Normalize();          //取得單位向量
            rb.AddForce(frontMove * force);
        }

        //方向鍵 左
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            frontMove = tf.right;
            frontMove.y = 0;                //令y軸方向向量歸零
            frontMove.Normalize();          //取得單位向量
            rb.AddForce(frontMove * -force);
        }

        //方向鍵 下
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            frontMove = tf.forward;
            frontMove.y = 0;                //令y軸方向向量歸零
            frontMove.Normalize();          //取得單位向量
            rb.AddForce(frontMove * -force);
        }

        //方向鍵 右
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            frontMove = tf.right;
            frontMove.y = 0;                //令y軸方向向量歸零
            frontMove.Normalize();          //取得單位向量
            rb.AddForce(frontMove * force);
        }
    }
}
