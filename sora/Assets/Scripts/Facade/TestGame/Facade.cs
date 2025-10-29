using System;
using UnityEngine;

namespace TestGame
{
    public class Facade
    {
        PlayerController playerController;
        public Facade()
        {
            playerController = new PlayerController();
        }

        public void GameUpdate()
        {
            playerController.OnUpdate();
        }
    }
}