using UnityEngine.SceneManagement;

public enum SceneName
{
    MainMenu,
    TestGame,
}

public class SceneModel: AModel
{
    public SceneName sceneName;
    public int SceneIndex;
    protected override void OnInit()
    {
        base.OnInit();
        SetData();
    }
    public void SetData()
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (SceneIndex)
        {
            case 0:
                sceneName = SceneName.MainMenu;
                break;
            case 1:
                sceneName = SceneName.TestGame;
                break;
        }
    }
}