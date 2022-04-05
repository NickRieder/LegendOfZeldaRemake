using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using Microsoft.Xna.Framework;
using System.Linq;

namespace Sprint2
{
    public class KeyboardController : IController
    {
        private KeyboardState currentState;
        private KeyboardState previousState;
        private Dictionary<Keys, ICommand> controllerMappingsHold;
        private Dictionary<Keys, ICommand> controllerMappingsTap;
        private Dictionary<Keys, ICommand> controllerMappingsRelease;
        private Dictionary<Keys, bool> currentKeyStates;
        private Dictionary<Keys, bool> previousKeyStates;
        private Keys[] previousPressedKeys;

        public KeyboardController()
        {
            previousPressedKeys = Keyboard.GetState().GetPressedKeys();
            controllerMappingsHold = new Dictionary<Keys, ICommand>();
            controllerMappingsTap = new Dictionary<Keys, ICommand>();
            controllerMappingsRelease = new Dictionary<Keys, ICommand>();
        }

        public void RegisterCommandHold(Keys key, ICommand command)
        {
            controllerMappingsHold.Add(key, command);
        }
        
        public void RegisterCommandTap(Keys key, ICommand command)
        {
            controllerMappingsTap.Add(key, command);
        }

        public void RegisterCommandRelease(Keys key, ICommand command)
        {
            controllerMappingsRelease.Add(key, command);
        }

        public void Initialize(Link link, Item item, Block block, Game1 game1, SoundFactory soundFactory)
        {
            RegisterCommandTap(Keys.I, new SetNextItem(item));
            RegisterCommandTap(Keys.U, new SetPreviousItem(item));

            RegisterCommandTap(Keys.Z, new SetLinkAttacking(link, soundFactory));
            RegisterCommandTap(Keys.N, new SetLinkAttacking(link, soundFactory));

            RegisterCommandTap(Keys.Y, new SetNextBlock(block));
            RegisterCommandTap(Keys.T, new SetPreviousBlock(block));

            RegisterCommandTap(Keys.D4, new SetLinkUseItem(link));
            RegisterCommandTap(Keys.D1, new SetLinkUseArrow(link));
            RegisterCommandTap(Keys.D2, new SetLinkUseBoomerang(link));
            RegisterCommandTap(Keys.D3, new SetLinkUseBomb(link));

            RegisterCommandHold(Keys.S, new SetLinkMoving(link));
            RegisterCommandHold(Keys.W, new SetLinkMoving(link));
            RegisterCommandHold(Keys.A, new SetLinkMoving(link));
            RegisterCommandHold(Keys.D, new SetLinkMoving(link));

            RegisterCommandTap(Keys.S, new SetLinkStandingDown(link));
            RegisterCommandTap(Keys.W, new SetLinkStandingUp(link));
            RegisterCommandTap(Keys.A, new SetLinkStandingLeft(link));
            RegisterCommandTap(Keys.D, new SetLinkStandingRight(link));

            RegisterCommandRelease(Keys.S, new SetLinkStandingDown(link));
            RegisterCommandRelease(Keys.W, new SetLinkStandingUp(link));
            RegisterCommandRelease(Keys.A, new SetLinkStandingLeft(link));
            RegisterCommandRelease(Keys.D, new SetLinkStandingRight(link));

            RegisterCommandTap(Keys.E, new SetTakeDamage(link));

            RegisterCommandTap(Keys.Down, new SetLinkStandingDown(link));
            RegisterCommandTap(Keys.Up, new SetLinkStandingUp(link));
            RegisterCommandTap(Keys.Left, new SetLinkStandingLeft(link));
            RegisterCommandTap(Keys.Right, new SetLinkStandingRight(link));

            RegisterCommandRelease(Keys.Down, new SetLinkStandingDown(link));
            RegisterCommandRelease(Keys.Up, new SetLinkStandingUp(link));
            RegisterCommandRelease(Keys.Left, new SetLinkStandingLeft(link));
            RegisterCommandRelease(Keys.Right, new SetLinkStandingRight(link));

            RegisterCommandHold(Keys.Down, new SetLinkMoving(link));
            RegisterCommandHold(Keys.Up, new SetLinkMoving(link));
            RegisterCommandHold(Keys.Left, new SetLinkMoving(link));
            RegisterCommandHold(Keys.Right, new SetLinkMoving(link));

            RegisterCommandTap(Keys.Q, new QuitCommand(game1));
            RegisterCommandTap(Keys.R, new ResetGame(game1));


        }

        public void Update(GameTime gameTime)
        {
            
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            currentState = Keyboard.GetState();

            foreach (Keys key in pressedKeys.Union<Keys>(previousPressedKeys))
            {
                if(controllerMappingsTap.ContainsKey(key) && Array.IndexOf(previousPressedKeys, key) == -1) {
                    controllerMappingsTap[key].Execute();
                }
                else if (controllerMappingsRelease.ContainsKey(key) && Array.IndexOf(previousPressedKeys, key) != -1 && Array.IndexOf(pressedKeys, key) == -1)
                {
                    controllerMappingsRelease[key].Execute();
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