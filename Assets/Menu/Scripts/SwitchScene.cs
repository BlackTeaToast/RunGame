using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour{

    void Start()
    {
        
    }

    public void SwitchToGame() {
        SceneManager.LoadScene("Scene_GrassRoadRace");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene_GrassRoadRace"));
    }

}
