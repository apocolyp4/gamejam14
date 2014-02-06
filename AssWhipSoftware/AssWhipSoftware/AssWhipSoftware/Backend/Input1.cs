using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AssWhipSoftware.Backend
{
    public class InputClass1
    {
        private KeyboardState currentState;
        private KeyboardState previousState;
        private GamePadState currentPadState;
        private GamePadState previousPadState;
        private List<Keys> keys;
        private List<Buttons> buttons;
        private float duration;

        public InputClass1()
        {
            currentState = Keyboard.GetState();
            buttons = new List<Buttons>();
            buttons.Add(Buttons.DPadLeft);
            buttons.Add(Buttons.DPadRight);
            buttons.Add(Buttons.DPadDown);
            buttons.Add(Buttons.DPadUp);
            buttons.Add(Buttons.A);
            buttons.Add(Buttons.B);
            buttons.Add(Buttons.X);
            buttons.Add(Buttons.Y);
            buttons.Add(Buttons.Start);
            buttons.Add(Microsoft.Xna.Framework.Input.Buttons.Back);
            /*keys = new List<Keys>();
            keys.Add(Microsoft.Xna.Framework.Input.Keys.A);
            keys.Add(Microsoft.Xna.Framework.Input.Keys.S);
            keys.Add(Microsoft.Xna.Framework.Input.Keys.D);
            keys.Add(Microsoft.Xna.Framework.Input.Keys.W);
            keys.Add(Microsoft.Xna.Framework.Input.Keys.K);
            keys.Add(Microsoft.Xna.Framework.Input.Keys.L);
            keys.Add(Microsoft.Xna.Framework.Input.Keys.O);
            keys.Add(Microsoft.Xna.Framework.Input.Keys.OemSemicolon);
            keys.Add(Microsoft.Xna.Framework.Input.Keys.P);
            keys.Add(Microsoft.Xna.Framework.Input.Keys.U);*/
            /*Keys.Add(Keys.A);
            Keys.Add(InputState.BITE);
            Keys.Add(InputState.CLAW);
            Keys.Add(InputState.DOWN);
            Keys.Add(InputState.JUMP);
            Keys.Add(InputState.LEFT);
            Keys.Add(InputState.PAUSE);
            Keys.Add(InputState.RIGHT);
            Keys.Add(InputState.SELECT);
            Keys.Add(InputState.UP);*/
        }

        public void Update()
        {
            previousState = currentState;
            previousPadState = currentPadState;
            currentState = Keyboard.GetState();
            currentPadState = GamePad.GetState(PlayerIndex.One);
            foreach (Buttons Button in buttons)
            {
                if (isButtonPressed(Button))
                    InputHandler.NextEvent = new InputEvent(GetButton(Button), InputType.PRESSED, 0);
                if (isButtonHeld(Button) > 0)
                    InputHandler.NextEvent = new InputEvent(GetButton(Button), InputType.HELD, isButtonHeld(Button));
                if (isButtonReleased(Button) > 0)
                    InputHandler.NextEvent = new InputEvent(GetButton(Button), InputType.RELEASED, isButtonReleased(Button));
                if (isButtonBeingHeld(Button))
                    InputHandler.NextEvent = new InputEvent(GetButton(Button), InputType.BEING_HELD, 0);
            }

        }

        private bool isButtonPressed(Buttons Button)
        {
            if (currentPadState.IsButtonDown(Button) && !(previousPadState.IsButtonDown(Button)))
                return true;
            return false;
            //return InputType.PRESSED;
        }

        private bool isButtonBeingHeld(Buttons Button)
        {
            if (currentPadState.IsButtonDown(Button))
                return true;
            return false;
            //return InputType.PRESSED;
        }

        private float isButtonHeld(Buttons Button)
        {
            if (currentPadState.IsButtonDown(Button) && (previousPadState.IsButtonDown(Button)))
            {
                duration += Settings.GameTime.ElapsedGameTime.Milliseconds;
                return Settings.GameTime.ElapsedGameTime.Milliseconds;
            }
            return 0;
        }

        private float isButtonReleased(Buttons Button)
        {
            if (!currentPadState.IsButtonDown(Button) && (previousPadState.IsButtonDown(Button)))
                return duration;
            return 0;
        }

        private InputState GetButton(Buttons button)
        {
            switch (button)
            {
                case Buttons.A:
                    return InputState.JUMP;
                case Buttons.B:
                    return InputState.ASSWHIP;
                case Buttons.X:
                    return InputState.CLAW;
                case Buttons.Y:
                    return InputState.BITE;
                case Buttons.DPadLeft:
                    return InputState.LEFT;
                case Buttons.DPadDown:
                    return InputState.DOWN;
                case Buttons.DPadRight:
                    return InputState.RIGHT;
                case Buttons.DPadUp:
                    return InputState.UP;
                case Buttons.Start:
                    return InputState.PAUSE;
                case Buttons.Back:
                    return InputState.SELECT;
                default:
                    return InputState.NULL;
            }
        }
    }

    
}
