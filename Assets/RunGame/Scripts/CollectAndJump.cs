using UnityEngine;
using System.Collections;

public class CollectAndJump : MonoBehaviour {
    private Rigidbody rb;
    public float power;//向上的力量
    public int amount;//要收集的數量
    public FallingDetector fallingDetector;//用來設置重生點用
    public bool collect;//勾選此選項即為收集模式
    public TextMesh foodAmount;
    
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        if (collect)
            foodAmount.text = "剩下數量： " + amount + " 個";
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jump")
        {
            rb.velocity += Vector3.up * power;
        }

        if (other.tag == "food"){
            amount--;
            if (amount == 0) {
                foodAmount.text = "";
                CollectionFinish.finish = true;
            }
            fallingDetector.resetPosition = transform.position;
            other.gameObject.SetActive(false);//將食物物件從遊戲中移除
            if (collect)
                foodAmount.text = "剩下數量： "+amount+" 個";
                
        }
    }
}
