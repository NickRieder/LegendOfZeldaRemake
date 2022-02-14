using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Sprint2
{
    class KeyboardController : IController
    {
        private KeyboardState currentState;
        private KeyboardState previousState;
        private Dictionary<Keys, ICommand> controllerMappingsHold;
        private Dictionary<Keys, ICommand> controllerMappingsTap;
        private Dictionary<Keys, bool> currentKeyStates;
        private Dictionary<Keys, bool> previousKeyStates;
        private Keys[] previousPressedKeys;

        public KeyboardController()
        {
            previousPressedKeys = Keyboard.GetState().GetPressedKeys();
            controllerMappingsHold = new Dictionary<Keys, ICommand>();
            controllerMappingsTap = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommandHold(Keys key, ICommand command)
        {
            controllerMappingsHold.Add(key, command);
        }
        
        public void RegisterCommandTap(Keys key, ICommand command)
        {
            controllerMappingsTap.Add(key, command);
        }

        public void update()
        {

            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            currentState = Keyboard.GetState();

            foreach (Keys key in pressedKeys)
            {
                if(controllerMappingsTap.ContainsKey(key) && Array.IndexOf(previousPressedKeys, key) == -1) {
                    controllerMappingsTap[key].Execute();
                }
                else if (controllerMappingsHold.ContainsKey(key))
                {
                    controllerMappingsHold[key].Execute();
                }

                

            }
            previousPressedKeys = pressedKeys;

        }

    }
}