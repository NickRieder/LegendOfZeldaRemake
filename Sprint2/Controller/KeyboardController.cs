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
        private Dictionary<Keys, ICommand> controllerMappingsHold;
        private Dictionary<Keys, ICommand> controllerMappingsTap;
        private Dictionary<Keys, ICommand> controllerMappingsRelease;
        private Dictionary<Keys, ICommand> controllerMappingsPause;
        private Keys[] previousPressedKeys;
        private bool isPaused;

        public KeyboardController()
        {
            previousPressedKeys = Keyboard.GetState().GetPressedKeys();
            controllerMappingsHold = new Dictionary<Keys, ICommand>();
            controllerMappingsTap = new Dictionary<Keys, ICommand>();
            controllerMappingsRelease = new Dictionary<Keys, ICommand>();
            controllerMappingsPause = new Dictionary<Keys, ICommand>();
            isPaused = false;
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

        public void RegisterCommandPause(Keys key, ICommand command)
        {
            controllerMappingsPause.Add(key, command);
        }

        public void SetPauseUnpauseState()
        {
            isPaused = !isPaused;
        }

        public void Initialize(GameObjectManager gom, Game1 game1, SoundFactory soundFactory)
        {

<<<<<<< HEAD
            RegisterCommandTap(Keys.D1, new SetLinkUseArrow(link));
            RegisterCommandTap(Keys.D2, new SetLinkUseBoomerang(link));
            RegisterCommandTap(Keys.D3, new SetLinkUseBomb(link));
=======
            RegisterCommandTap(Keys.D4, new SetLinkUseItem(gom.link));
            RegisterCommandTap(Keys.D1, new SetLinkUseArrow(gom.link, soundFactory));
            RegisterCommandTap(Keys.D2, new SetLinkUseBoomerang(gom.link, soundFactory));
            RegisterCommandTap(Keys.D3, new SetLinkUseBomb(gom.link, soundFactory));
            RegisterCommandTap(Keys.Z, new SetLinkAttacking(gom.link, soundFactory));
            RegisterCommandTap(Keys.N, new SetLinkAttacking(gom.link, soundFactory));

            RegisterCommandTap(Keys.P, new PauseGame(gom, this));
>>>>>>> origin/Sprint4

            RegisterCommandHold(Keys.S, new SetLinkMoving(gom.link));
            RegisterCommandHold(Keys.W, new SetLinkMoving(gom.link));
            RegisterCommandHold(Keys.A, new SetLinkMoving(gom.link));
            RegisterCommandHold(Keys.D, new SetLinkMoving(gom.link));

            RegisterCommandTap(Keys.S, new SetLinkStandingDown(gom.link));
            RegisterCommandTap(Keys.W, new SetLinkStandingUp(gom.link));
            RegisterCommandTap(Keys.A, new SetLinkStandingLeft(gom.link));
            RegisterCommandTap(Keys.D, new SetLinkStandingRight(gom.link));

            RegisterCommandRelease(Keys.S, new SetLinkStandingDown(gom.link));
            RegisterCommandRelease(Keys.W, new SetLinkStandingUp(gom.link));
            RegisterCommandRelease(Keys.A, new SetLinkStandingLeft(gom.link));
            RegisterCommandRelease(Keys.D, new SetLinkStandingRight(gom.link));

            RegisterCommandTap(Keys.E, new SetTakeDamage(gom.link));

            RegisterCommandTap(Keys.Down, new SetLinkStandingDown(gom.link));
            RegisterCommandTap(Keys.Up, new SetLinkStandingUp(gom.link));
            RegisterCommandTap(Keys.Left, new SetLinkStandingLeft(gom.link));
            RegisterCommandTap(Keys.Right, new SetLinkStandingRight(gom.link));

            RegisterCommandRelease(Keys.Down, new SetLinkStandingDown(gom.link));
            RegisterCommandRelease(Keys.Up, new SetLinkStandingUp(gom.link));
            RegisterCommandRelease(Keys.Left, new SetLinkStandingLeft(gom.link));
            RegisterCommandRelease(Keys.Right, new SetLinkStandingRight(gom.link));

            RegisterCommandHold(Keys.Down, new SetLinkMoving(gom.link));
            RegisterCommandHold(Keys.Up, new SetLinkMoving(gom.link));
            RegisterCommandHold(Keys.Left, new SetLinkMoving(gom.link));
            RegisterCommandHold(Keys.Right, new SetLinkMoving(gom.link));

            RegisterCommandTap(Keys.Q, new QuitCommand(game1));
            RegisterCommandTap(Keys.R, new ResetGame(game1));
<<<<<<< HEAD
=======

            RegisterCommandPause(Keys.P, new PauseGame(gom, this));

            RegisterCommandTap(Keys.NumPad6, new SetCameraMovingRight(game1.camera));
            RegisterCommandTap(Keys.NumPad4, new SetCameraMovingLeft(game1.camera));
            RegisterCommandTap(Keys.NumPad8, new SetCameraMovingUp(game1.camera));
            RegisterCommandTap(Keys.NumPad5, new SetCameraMovingDown(game1.camera));


>>>>>>> origin/Sprint4
        }

        public void Update(GameTime gameTime)
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            if(!isPaused)
            {
                foreach (Keys key in pressedKeys.Union(previousPressedKeys))
                {
                    if (controllerMappingsTap.ContainsKey(key) && Array.IndexOf(previousPressedKeys, key) == -1)
                    {
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
            }
            else
            {
                foreach (Keys key in pressedKeys)
                {
                    if(controllerMappingsPause.ContainsKey(key) && Array.IndexOf(previousPressedKeys, key) == -1)
                    {
                        controllerMappingsPause[key].Execute();
                    }
                    
                }
            }
            previousPressedKeys = pressedKeys;
        }
    }
}