using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour{

    void Start()
    {
        
    }

    public void SwitchToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));
    }

    public void SwitchToGame() {
        SceneManager.LoadSceneAsync("Scene_GrassRoadRace");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene_GrassRoadRace"));
    }

    public void SwitchToSettingMode()
    {
        SceneManager.LoadSceneAsync("SettingMode");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("SettingMode"));
    }

}
