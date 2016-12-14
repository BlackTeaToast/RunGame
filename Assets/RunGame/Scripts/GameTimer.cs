using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour
{

    public static float time = 0;
    // Use this for initialization
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
}
