using UnityEngine;
using System.Collections;

public class SwitchLength : MonoBehaviour {

    // Use this for initialization
    public GameObject LengthPanel;
    public GameObject ShortDistance;
    public GameObject MiddleDistance;

    public void SwitchToShortDistance()
    {
        LengthPanel.SetActive(false);
    }

    public void SwitchToMiddleDistance()
    {
        ShortDistance.SetActive(false);
        LengthPanel.SetActive(false);           
    }
    public void SwitchToLongDistance()
    {
        ShortDistance.SetActive(false);
        MiddleDistance.SetActive(false);
        LengthPanel.SetActive(false);
    }
    
}
