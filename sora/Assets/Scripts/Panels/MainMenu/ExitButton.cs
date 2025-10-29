using System;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton: APanel
{
    public ExitButton(): base(null)
    {
        gameObject = GameObject.Find("ExitButton");
        if (gameObject != null)
        {
            Button _exitButton = gameObject.GetComponent<Button>();
            _exitButton.onClick.AddListener(OnClick);
        }
    }
    protected override void OnClick()
    {
        base.OnClick();
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