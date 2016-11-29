using UnityEngine;
using System.Collections;

public class SwitchPanel : MonoBehaviour
{

    public GameObject MainPanel;
    public GameObject StageTypePanel;
    public GameObject RunStagePanel;
    public GameObject CollectStagePanel;

    public void SwitchStageTypePanelToMainPanel()
    {
        StageTypePanel.SetActive(false);
        MainPanel.SetActive(true);
    }
    public void SwitchMainPanelToStageTypePanel()
    {
        MainPanel.SetActive(false);
        StageTypePanel.SetActive(true);
    }
    public void SwitchStageTypePanelToRunStagePanel()
    {
        StageTypePanel.SetActive(false);
        RunStagePanel.SetActive(true);
    }
    public void SwitchRunStagePanelToStageTypePanel()
    {
        RunStagePanel.SetActive(false);
        StageTypePanel.SetActive(true);
    }
    public void SwitchStageTypePanelToCollectStagePanel()
    {
        StageTypePanel.SetActive(false);
        CollectStagePanel.SetActive(true);
    }
    public void SwitchCollectStagePanelToStageTypePanel()
    {
        CollectStagePanel.SetActive(false);
        StageTypePanel.SetActive(true);
    }
}
