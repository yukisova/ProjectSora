using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class PanelRoot: APanel
    {
        private Button exitButton;
        private Button startButton;
        public PanelRoot() : base(null){}
        protected override void OnInit()
        {
            base.OnInit();
            Resume();
            EventCenter.Instance.RegisterObserver(EventType.OnSceneChangeComplete, () => {});

            exitButton = SoraUtil.getComponentFormChildren<Button>(theGameObject, "ExitButton");
            exitButton.onClick.AddListener(() => OnExitButtonClick());
            startButton = SoraUtil.getComponentFormChildren<Button>(theGameObject, "StartButton");
            startButton.onClick.AddListener(() => OnStartButtonClick());
        }

        private void OnExitButtonClick()
        {
            Debug.Log("Exit Button Clicked!");
            // Add logic to exit the game
            #if UNITY_EDITOR
                // 如果在Unity编辑器中运行，则退出播放模式
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                // 在打包后的游戏中退出应用
                Application.Quit();
            #endif
        }
        private void OnStartButtonClick()
        {
            Debug.Log("Start Button Clicked!");
            // Add logic to start the game
            SceneCommand.Instance.LoadScene(SceneName.TestGame);
        }
    }
}