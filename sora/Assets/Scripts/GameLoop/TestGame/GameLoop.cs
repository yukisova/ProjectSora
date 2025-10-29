using System;
using UnityEngine;

namespace TestGame
{
    public class GameLoop : AGameLoop
    {
        private Facade _facade;
        private void Start()
        {
            _facade = new Facade();
        }

        private void Update()
        {
            _facade.GameUpdate();
        }
    }
}