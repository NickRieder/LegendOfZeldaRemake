using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using Microsoft.Xna.Framework;

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

        public void Initialize(Link link, Item item, Block block, EnemiesList enemiesList, Game1 game1)
        {
            RegisterCommandTap(Keys.I, new SetNextItem(item));
            RegisterCommandTap(Keys.U, new SetPreviousItem(item));

            RegisterCommandTap(Keys.Z, new SetLinkAttacking(link));
            RegisterCommandTap(Keys.N, new SetLinkAttacking(link));

            RegisterCommandTap(Keys.Y, new SetNextBlock(block));
            RegisterCommandTap(Keys.T, new SetPreviousBlock(block));

            RegisterCommandTap(Keys.P, new SetNextEnemy(enemiesList));
            RegisterCommandTap(Keys.O, new SetPreviousEnemy(enemiesList));

            RegisterCommandTap(Keys.D1, new SetLinkUseArrow(link));
            RegisterCommandTap(Keys.D2, new SetLinkUseBoomerang(link));
            RegisterCommandTap(Keys.D3, new SetLinkUseBomb(link));

            RegisterCommandHold(Keys.S, new SetLinkMovingDown(link));
            RegisterCommandHold(Keys.W, new SetLinkMovingUp(link));
            RegisterCommandHold(Keys.A, new SetLinkMovingLeft(link));
            RegisterCommandHold(Keys.D, new SetLinkMovingRight(link));

            RegisterCommandTap(Keys.E, new SetLinkDamagedDown(link));

            RegisterCommandHold(Keys.Down, new SetLinkMovingDown(link));
            RegisterCommandHold(Keys.Up, new SetLinkMovingUp(link));
            RegisterCommandHold(Keys.Left, new SetLinkMovingLeft(link));
            RegisterCommandHold(Keys.Right, new SetLinkMovingRight(link));

            RegisterCommandHold(Keys.Q, new QuitCommand(game1));
            RegisterCommandHold(Keys.R, new ResetGame(game1));


        }

        public void Update(GameTime gameTime)
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