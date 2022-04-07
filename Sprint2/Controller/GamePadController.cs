using System;
using System.Collections.Generic;
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
        private GamePadButtons[] previousPressedButtons;

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
        }
    }
}
