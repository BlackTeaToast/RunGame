using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Gvr;

public class PhoneController : MonoBehaviour {

    private const float Y_MOVE_DEFAULT = 0.15f;    //預設值
    private Rigidbody rb;
    private float yMove;    //震動觸發移動的值
    private float yOld = 0;

    public Transform Head;
    public float maxVelocity = 6;//拿來控制能夠加速的最高速度
    public float force = 50; //控制移動的力道大小

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        
        yMove = PlayerPrefs.GetFloat("Y_MOVE", Y_MOVE_DEFAULT);  //取得震動y值觸發移動
    }
	
	// Update is called once per frame
	void Update () {
        
        //新的加速度與舊的加速度取差值
        float dy = Mathf.Abs(Input.acceleration.y - yOld);

        if (dy > yMove)
            move();

        yOld = Input.acceleration.y;
    }
     
    void move()
    {
        //若不超過最大速限，則給予推力
        if (rb.velocity.y <= maxVelocity)
        {
            Vector3 frontMove = Head.forward;
            frontMove.y = 0;//令y軸方向向量歸零
            frontMove.Normalize();//取得單位向量
            rb.AddForce(frontMove * force);
        }

    }

}
