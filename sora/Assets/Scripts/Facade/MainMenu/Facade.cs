using System;
using UnityEngine;

namespace MainMenu
{
    public class Facade
    {
        public UIController uiController;
        public Facade()
        {
            uiController = new UIController();
        }

        public void GameUpdate()
        {
            uiController.GameUpdate();
        }
    }
}