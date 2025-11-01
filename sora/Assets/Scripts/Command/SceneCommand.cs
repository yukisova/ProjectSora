using UnityEngine;
using UnityEngine.SceneManagement;

/// 用于访问场景数据
public class SceneCommand: SingleTon<SceneCommand>
{
    private SceneModel model;
    private AsyncOperation op;
    private SceneCommand()
    {
        model = ModelContainer.Instance.GetModel<SceneModel>();
    }
    public void LoadScene(SceneName name)
    {
        op = SceneManager.LoadSceneAsync(GetSceneIndex(name));
        op.completed += OnSceneChangeCompelete;
    }
    private void OnSceneChangeCompelete(AsyncOperation op)
    {
        model.SetData();
        EventCenter.Instance.NotisfyObserver(EventType.OnSceneChangeComplete);
        EventCenter.Instance.ClearObserver();
    }
    public SceneName GetActiveSceneName()
    {
        return model.sceneName;
    }
    public int GetActiveSceneIndex()
    {
        return model.SceneIndex;
    }
    public int GetSceneIndex(SceneName name)
    {
        int result = 0;
        switch (name)
        {
            case SceneName.MainMenu:
                result = 0;
                break;
            case SceneName.TestGame:
                result = 1;
                break;
        }
        return result;
    }
}