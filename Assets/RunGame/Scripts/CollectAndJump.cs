using UnityEngine;
using System.Collections;

public class CollectAndJump : MonoBehaviour {
    private Rigidbody rb;
    public float power;
    private int amount;//要收集的數量

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        amount = 0;
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
            amount++;
            other.gameObject.SetActive(false);//將食物物件從遊戲中移除
        }
    }
}
