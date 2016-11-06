using UnityEngine;
using System.Collections;

public class TestNetwork : MonoBehaviour
{

    public string url = "http://ec2-52-26-84-202.us-west-2.compute.amazonaws.com:3000/";

    void Start()
    {
        StartCoroutine(DoWWW());
    }

    private IEnumerator DoWWW()
    {
        WWW hs_post = new WWW(url);
        yield return hs_post;
        print(hs_post.text);
    }

    public static bool Test()
    {
        WWW www = new WWW("http://ec2-52-26-84-202.us-west-2.compute.amazonaws.com:3000/");
        if(www.text == "Welcome!")
        {
            return true;
        } else {
            return false;
        }
    } 
}
