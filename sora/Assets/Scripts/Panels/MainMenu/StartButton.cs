using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton: APanel
{
    public StartButton(): base(null)
    {
        gameObject = GameObject.Find("StartButton");
        if (gameObject != null)
        {
            Button _startButton = gameObject.GetComponent<Button>();
            _startButton.onClick.AddListener(OnClick);
        }
    }
    protected override void OnClick()
    {
        base.OnClick();
        Debug.Log("Start Button Clicked!");
        // Add logic to start the game
        SceneManager.LoadScene("Scenes/TestScene");
    }
}