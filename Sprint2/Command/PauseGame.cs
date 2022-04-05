using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class PauseGame : ICommand
    {
        private GameObjectManager gom;
        private KeyboardController keyboardController;
        public PauseGame(GameObjectManager gom, KeyboardController keyboardController)
        {
            this.gom = gom;
            this.keyboardController = keyboardController;
        }

        public void Execute()
        {
            gom.PauseGame();
            keyboardController.SetPauseUnpauseState();
        }
    }
}
