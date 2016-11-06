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

    public void SwitchToGame2()
    {
        SceneManager.LoadScene("Scene_GrassRoadRace 1");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene_GrassRoadRace 1"));
    }

    public void SwitchToGame3()
    {
        SceneManager.LoadScene("Scene_GrassRoadRace 2");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene_GrassRoadRace 2"));
    }

    public void SwitchToGame4()
    {
        SceneManager.LoadScene("Scene_GrassRoadRace 3");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene_GrassRoadRace 3"));
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
