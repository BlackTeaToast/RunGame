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

    public void SwitchToRunGame1() {
        SceneManager.LoadScene("Scene_GrassRoadRace 5");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene_GrassRoadRace 5"));
    }

    public void SwitchToRunGame2()
    {
        SceneManager.LoadScene("Scene_GrassRoadRace 4");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene_GrassRoadRace 4"));
    }

    public void SwitchToRunGame3()
    {
        SceneManager.LoadScene("Scene_GrassRoadRace");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene_GrassRoadRace"));
    }

    public void SwitchToCollectGame1()
    {
        SceneManager.LoadScene("Scene_Park01");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene_Park01"));
    }

    public void SwitchToCollectGame2()
    {
        SceneManager.LoadScene("Scene_Park02");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene_Park02"));
    }

    public void SwitchToCollectGame3()
    {
        SceneManager.LoadScene("Scene_Park03");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene_Park03"));
    }

    public void SwitchToRunMachineGame()
    {
        SceneManager.LoadScene("Scene_GrassRoadRace Line");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Scene_GrassRoadRace Line"));
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
