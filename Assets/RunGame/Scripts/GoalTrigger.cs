using UnityEngine;
using System.Collections;

public class GoalTrigger : MonoBehaviour
{
    public static bool isClear;
    // Use this for initialization
    void Start()
    {
        isClear = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        isClear = true;
    }
}