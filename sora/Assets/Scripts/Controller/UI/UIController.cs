using UnityEngine;

public class UIController: AController
{
    private APanel rootPanel;

    public UIController(){}
    protected override void OnInit()
    {
        base.OnInit();
        SceneName sceneName = SceneCommand.Instance.GetActiveSceneName();
        switch (sceneName)
        {
            case SceneName.MainMenu:
                rootPanel = new MainMenu.PanelRoot();
                break;
            case SceneName.TestGame:
                rootPanel = new TestGame.PanelRoot();
                break;
        }
    }

    protected override void AlwaysUpdate()
    {
        base.AlwaysUpdate();
        rootPanel.GameUpdate();
    }
}