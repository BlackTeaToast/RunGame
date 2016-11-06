using UnityEngine;
using System.Collections;

public class SwitchPanel : MonoBehaviour
{

    public GameObject panel1;
    public GameObject panel2;

    public void SwitchToPanel1()
    {
        panel2.SetActive(false);
        panel1.SetActive(true);
    }
    public void SwitchToPanel2()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }
}
