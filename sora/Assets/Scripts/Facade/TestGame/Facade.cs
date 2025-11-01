using System;
using UnityEngine;

namespace TestGame
{
    public class Facade
    {
        PlayerController playerController;
        UIController uiController;
        public Facade()
        {
            playerController = new PlayerController();
        }

        public void GameUpdate()
        {
            playerController.GameUpdate();
        }
    }
}