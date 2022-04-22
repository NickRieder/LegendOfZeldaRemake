using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.Windows.Input;
using System.Collections;
using Microsoft.Xna.Framework;
using System.Linq;
using Sprint2.Command;
using Sprint2.GameStates;
using Microsoft.Xna.Framework.Graphics;

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

        public void Initialize(GameObjectManager gom, Game1 game1, SoundFactory soundFactory, SpriteFactory spriteFactory, SpriteBatch spriteBatch)
        {

            RegisterCommandTap(Keys.C, new SetLinkUseItem(gom.link));
            RegisterCommandTap(Keys.Z, new SetLinkAttacking(gom.link, soundFactory));
            RegisterCommandTap(Keys.N, new SetLinkAttacking(gom.link, soundFactory));

            RegisterCommandTap(Keys.P, new PauseGame(gom, this));

            RegisterCommandHold(Keys.S, new SetLinkMoving(gom.link, "down"));
            RegisterCommandHold(Keys.W, new SetLinkMoving(gom.link, "up"));
            RegisterCommandHold(Keys.A, new SetLinkMoving(gom.link, "left"));
            RegisterCommandHold(Keys.D, new SetLinkMoving(gom.link, "right"));

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

            RegisterCommandHold(Keys.Down, new SetLinkMoving(gom.link, "down"));
            RegisterCommandHold(Keys.Up, new SetLinkMoving(gom.link, "up"));
            RegisterCommandHold(Keys.Left, new SetLinkMoving(gom.link, "left"));
            RegisterCommandHold(Keys.Right, new SetLinkMoving(gom.link, "right"));

            RegisterCommandTap(Keys.Q, new QuitCommand(game1));
            RegisterCommandTap(Keys.R, new ResetGame(game1));
            RegisterCommandTap(Keys.Enter, new ResetGame(game1)); // for after winning screen

            RegisterCommandPause(Keys.P, new PauseGame(gom, this));
            RegisterCommandPause(Keys.A, new SetPreviousItem(gom.menu));
            RegisterCommandPause(Keys.D, new SetNextItem(gom.menu));
            RegisterCommandPause(Keys.Z, new SetLinkItem(gom.menu));

            RegisterCommandTap(Keys.M, new SetWinningState(gom.camera, spriteFactory, spriteBatch));
          
        }

        public void Update(GameTime gameTime)
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            if (!isPaused)
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
                        /*if (key == Keys.D)
                        {
                            if (!pressedKeys.Contains<Keys>(Keys.A) && !pressedKeys.Contains<Keys>(Keys.S) && !pressedKeys.Contains<Keys>(Keys.W))
                                controllerMappingsHold[key].Execute();
                        }
                        else if (key == Keys.W)
                        {
                            if (!pressedKeys.Contains<Keys>(Keys.A) && !pressedKeys.Contains<Keys>(Keys.S) && !pressedKeys.Contains<Keys>(Keys.D))
                                controllerMappingsHold[key].Execute();
                        }
                        else if (key == Keys.A)
                        {
                            if (!pressedKeys.Contains<Keys>(Keys.D) && !pressedKeys.Contains<Keys>(Keys.S) && !pressedKeys.Contains<Keys>(Keys.W))
                                controllerMappingsHold[key].Execute();
                        }
                        else if (key == Keys.S)
                        {
                            if (!pressedKeys.Contains<Keys>(Keys.A) && !pressedKeys.Contains<Keys>(Keys.D) && !pressedKeys.Contains<Keys>(Keys.W))
                                */
                        controllerMappingsHold[key].Execute();
                       // }
                    }
                }
            }
            else
            {
                foreach (Keys key in pressedKeys)
                {
                    if (controllerMappingsPause.ContainsKey(key) && Array.IndexOf(previousPressedKeys, key) == -1)
                    {
                        controllerMappingsPause[key].Execute();
                    }

                }
            }
            previousPressedKeys = pressedKeys;
        }
    }
}