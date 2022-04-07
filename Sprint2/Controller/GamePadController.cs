using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Sprint2.Controller
{
    public class GamePadController : IController
    {
        private Link link;
        private Dictionary<Buttons, ICommand> controllerMappingsHold;
        private Dictionary<Buttons, ICommand> controllerMappingsTap;
        private Dictionary<Buttons, ICommand> controllerMappingsRelease;

        private Buttons[] pressedButtons = new Buttons[0];

        public GamePadController()
        {
            controllerMappingsHold = new Dictionary<Buttons, ICommand>();
            controllerMappingsTap = new Dictionary<Buttons, ICommand>();
            controllerMappingsRelease = new Dictionary<Buttons, ICommand>();
        }

        public void RegisterCommandHold(Buttons gpbutton, ICommand command)
        {
            controllerMappingsHold.Add(gpbutton, command);
        }

        public void RegisterCommandTap(Buttons gpbutton, ICommand command)
        {
            controllerMappingsTap.Add(gpbutton, command);
        }

        public void RegisterCommandRelease(Buttons gpbutton, ICommand command)
        {
            controllerMappingsRelease.Add(gpbutton, command);
        }

        public void Initialize(Link link, Item item, Block block, Game1 game1)
        {
            // movement - needs hold tap release - DPadD
            RegisterCommandHold(Buttons.DPadDown, new SetLinkMoving(link));
            RegisterCommandHold(Buttons.DPadUp, new SetLinkMoving(link));
            RegisterCommandHold(Buttons.DPadLeft, new SetLinkMoving(link));
            RegisterCommandHold(Buttons.DPadRight, new SetLinkMoving(link));

            RegisterCommandTap(Buttons.DPadDown, new SetLinkStandingDown(link));
            RegisterCommandTap(Buttons.DPadUp, new SetLinkStandingUp(link));
            RegisterCommandTap(Buttons.DPadLeft, new SetLinkStandingLeft(link));
            RegisterCommandTap(Buttons.DPadRight, new SetLinkStandingRight(link));

            RegisterCommandRelease(Buttons.DPadDown, new SetLinkStandingDown(link));
            RegisterCommandRelease(Buttons.DPadUp, new SetLinkStandingUp(link));
            RegisterCommandRelease(Buttons.DPadLeft, new SetLinkStandingLeft(link));
            RegisterCommandRelease(Buttons.DPadRight, new SetLinkStandingRight(link));

            // movement - needs hold tap release - joy stick
            RegisterCommandHold(Buttons.LeftThumbstickDown, new SetLinkMoving(link));
            RegisterCommandHold(Buttons.LeftThumbstickUp, new SetLinkMoving(link));
            RegisterCommandHold(Buttons.LeftThumbstickLeft, new SetLinkMoving(link));
            RegisterCommandHold(Buttons.LeftThumbstickRight, new SetLinkMoving(link));

            RegisterCommandTap(Buttons.LeftThumbstickDown, new SetLinkStandingDown(link));
            RegisterCommandTap(Buttons.LeftThumbstickUp, new SetLinkStandingUp(link));
            RegisterCommandTap(Buttons.LeftThumbstickLeft, new SetLinkStandingLeft(link));
            RegisterCommandTap(Buttons.LeftThumbstickRight, new SetLinkStandingRight(link));

            RegisterCommandRelease(Buttons.LeftThumbstickDown, new SetLinkStandingDown(link));
            RegisterCommandRelease(Buttons.LeftThumbstickUp, new SetLinkStandingUp(link));
            RegisterCommandRelease(Buttons.LeftThumbstickLeft, new SetLinkStandingLeft(link));
            RegisterCommandRelease(Buttons.LeftThumbstickRight, new SetLinkStandingRight(link));

            // x for quit, y for reset
            RegisterCommandTap(Buttons.X, new QuitCommand(game1));
            RegisterCommandTap(Buttons.Y, new ResetGame(game1));

            // using arrow boomerang bomb
            RegisterCommandTap(Buttons.RightThumbstickUp, new SetLinkUseArrow(link));
            RegisterCommandTap(Buttons.RightThumbstickLeft, new SetLinkUseBoomerang(link));
            RegisterCommandTap(Buttons.RightThumbstickRight, new SetLinkUseBomb(link));

            // Pause - UNCOMMENT WHEN MERGED
            // RegisterCommandTap(Buttons.Start, new SetLinkUseArrow(link));
        }

        public void Update(GameTime gameTime)
        {
            GamePadState state = GamePad.GetState(PlayerIndex.One);

            List<Buttons> tempList = new List<Buttons>();
            if (GamePad.GetState(0).DPad.Left == ButtonState.Pressed)
            {
                tempList.Add(Buttons.DPadLeft);
            }
            if (GamePad.GetState(0).DPad.Right == ButtonState.Pressed)
            {
                tempList.Add(Buttons.DPadRight);
            }
            if (GamePad.GetState(0).DPad.Up == ButtonState.Pressed)
            {
                tempList.Add(Buttons.DPadUp);
            }
            if (GamePad.GetState(0).DPad.Down == ButtonState.Pressed)
            {
                tempList.Add(Buttons.DPadDown);
            }

            Buttons[] pressedKeys = new Buttons[tempList.LongCount()];
            for (int i = 0; i < pressedKeys.LongCount(); i++)
            {
                pressedKeys[i] = tempList[i];
            }

            if (Left(pressedKeys))
            {
                controllerMappingsTap[Buttons.DPadLeft].Execute();
            }
            else if (Right(pressedKeys))
            {
                controllerMappingsTap[Buttons.DPadRight].Execute();
            }
            else if (Up(pressedKeys))
            {
                controllerMappingsTap[Buttons.DPadUp].Execute();
            }
            else if (Down(pressedKeys))
            {
                controllerMappingsTap[Buttons.DPadDown].Execute();
            }
        
            if (pressedButtons != null)
            {
                foreach (Buttons button in pressedButtons)
                {
                    if (pressedButtons.Contains(button) && GamePad.GetState(0).IsButtonUp(button))
                    {
                        controllerMappingsRelease[button].Execute();
                    }
                }
            }
            pressedButtons = pressedKeys;
        }

        private bool Left(Buttons[] pressedKeys)
        {
            return pressedKeys.Contains(Buttons.DPadLeft) &&
                !pressedKeys.Contains(Buttons.DPadRight) &&
                !pressedKeys.Contains(Buttons.DPadUp) &&
                !pressedKeys.Contains(Buttons.DPadDown);
        }
        private bool Right(Buttons[] pressedKeys)
        {
            return !pressedKeys.Contains(Buttons.DPadLeft) &&
                !pressedKeys.Contains(Buttons.DPadUp) &&
                pressedKeys.Contains(Buttons.DPadRight) &&
                !pressedKeys.Contains(Buttons.DPadDown);
        }
        private bool Up(Buttons[] pressedKeys)
        {
            return !pressedKeys.Contains(Buttons.DPadLeft) &&
                 !pressedKeys.Contains(Buttons.DPadRight) &&
                 pressedKeys.Contains(Buttons.DPadUp) &&
                 !pressedKeys.Contains(Buttons.DPadDown);
        }
        private bool Down(Buttons[] pressedKeys)
        {
            return !pressedKeys.Contains(Buttons.DPadLeft) &&
                !pressedKeys.Contains(Buttons.DPadRight) &&
                !pressedKeys.Contains(Buttons.DPadUp) &&
                pressedKeys.Contains(Buttons.DPadDown);
        }
    }
}
