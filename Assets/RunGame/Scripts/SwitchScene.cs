using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour{

    void Start()
    {
        
    }

    public void SwitchToMenu()
    {
        SceneManager.LoadScene("Menu");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));
    }

    public void SwitchToGame() {
        SceneManager.LoadScene("Scene_GrassRoadRace");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene_GrassRoadRace"));
    }

    public void SwitchToSettingMode()
    {
        SceneManager.LoadScene("SettingMode");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("SettingMode"));
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
