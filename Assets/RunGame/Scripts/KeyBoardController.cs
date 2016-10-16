using UnityEngine;
using System.Collections;

public class KeyBoardController : MonoBehaviour {

    private Rigidbody rb;
    public Transform Head;

    public float force = 10; //控制移動的力道大小
    

    // Use this for initialization
    void Start () {
	    rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //方向鍵 上
	    if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Vector3 forward = Head.forward;
            forward.y = 0;                //令y軸方向向量歸零
            forward.Normalize();          //取得單位向量
            rb.AddForce(forward * force);
        }

        //方向鍵 左
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Vector3 right = Head.right;
            right.y = 0;                //令y軸方向向量歸零
            right.Normalize();          //取得單位向量
            rb.AddForce(right * -force);
        }

        //方向鍵 下
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Vector3 forward = Head.forward;
            forward.y = 0;                //令y軸方向向量歸零
            forward.Normalize();          //取得單位向量
            rb.AddForce(forward * -force);
        }

        //方向鍵 右
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Vector3 right = Head.right;
            right.y = 0;                //令y軸方向向量歸零
            right.Normalize();          //取得單位向量
            rb.AddForce(right * force);
        }

        //視角 左
        if (Input.GetKey(KeyCode.Q))
        {
            Head.Rotate(new Vector3(0, -1, 0));
        }

        //視角 右
        if (Input.GetKey(KeyCode.E))
        {
            Head.Rotate(new Vector3(0, 1, 0));
        }

        //視角 上
        if (Input.GetKey(KeyCode.R))
        {
            Head.Rotate(new Vector3(-1, 0, 0));
        }

        //視角 下
        if (Input.GetKey(KeyCode.F))
        {
            Head.Rotate(new Vector3(1, 0, 0));
        }

        //跳躍
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 1, 0) * force);
        }
    }
}
