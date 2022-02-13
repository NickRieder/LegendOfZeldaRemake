using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Sprint2
{
    class KeyboardController : IController
    {
        private int currentState;
        private Dictionary<Keys, ICommand> controllerMappings;

        public KeyboardController()
        {
            currentState = 1;
            controllerMappings = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void update()
        {

            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                controllerMappings[key].Execute();
            }

        }

    }
}