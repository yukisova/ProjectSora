using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class UIController
    {
        private Button _startButton;
        private Button _exitButton;
        public UIController()
        {
            GameObject startButtonObj = GameObject.Find("StartButton");
            if (startButtonObj != null)
            {
                _startButton = startButtonObj.GetComponent<Button>();
                _startButton.onClick.AddListener(OnStartButtonClicked);
            }

            GameObject exitButtonObj = GameObject.Find("ExitButton");
            if (exitButtonObj != null)
            {
                _exitButton = exitButtonObj.GetComponent<Button>();
                _exitButton.onClick.AddListener(OnExitButtonClicked);
            }
        }

        public void OnStartButtonClicked()
        {
            Debug.Log("Start Button Clicked!");
            // Add logic to start the game
            SceneManager.LoadScene("Scenes/TestScene");
        }

        public void OnExitButtonClicked()
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
    }
}