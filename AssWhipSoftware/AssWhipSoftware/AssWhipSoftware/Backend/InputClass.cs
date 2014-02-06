using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace AssWhipSoftware.Backend
{
    public class InputClass
    {
        private KeyboardState currentKeyState;
        private KeyboardState previousKeyState;
        private GamePadState currentPadState;
        private GamePadState previousPadState;
        private float stickMinMovement; 

        public InputClass()
        {
        }

        public void Update()
        {
            stickMinMovement = 0.2f;
            previousKeyState = currentKeyState;
            previousPadState = currentPadState;
            currentKeyState = Keyboard.GetState();
            currentPadState = GamePad.GetState(PlayerIndex.One);
            updateSelect();
            updateJump();
            updateArseWhip();
            updateBite();
            updateClaw();
            updateLeft();
            updateRight();
            updateUp();
            updateDown();
        }

        public void updateJump()
        {
            //Controls.jumpDuration  
            Controls.jumpPressed = false;
            Controls.jumpReleased = false;
            Controls.jumpState = false;

            if (isButtonPressed(Buttons.A) || isKeyPressed(Keys.Space))
                Controls.jumpPressed = true;

            if (isButtonReleased(Buttons.A) || isKeyReleased(Keys.Space))
                Controls.jumpReleased = true;

            if (isButtonHeld(Buttons.A) || isKeyHeld(Keys.Space))
                Controls.jumpState = true;
        }


        public void updateArseWhip()
        {
            Controls.arseWhipPressed = false;
            Controls.arseWhipReleased = false;
            Controls.arseWhipState = false;

            if (isButtonPressed(Buttons.X) || isKeyPressed(Keys.S))
                Controls.arseWhipPressed = true;

            if (isButtonReleased(Buttons.X) || isKeyReleased(Keys.S))
                Controls.arseWhipReleased = true;

            if (isButtonHeld(Buttons.X) || isKeyHeld(Keys.S))
                Controls.arseWhipState = true;
        }

        public void updateBite()
        {
            Controls.bitePressed = false;
            Controls.biteReleased = false;
            Controls.biteState = false;

            if (isButtonPressed(Buttons.Y) || isKeyPressed(Keys.D))
                Controls.bitePressed = true;

            if (isButtonReleased(Buttons.Y) || isKeyReleased(Keys.D))
                Controls.biteReleased = true;

            if (isButtonHeld(Buttons.Y) || isKeyHeld(Keys.D))
                Controls.biteState = true;
        }

        public void updateClaw()
        {
            Controls.clawPressed = false;
            Controls.clawReleased = false;
            Controls.clawState = false;

            if (isButtonPressed(Buttons.B) || isKeyPressed(Keys.A))
                Controls.clawPressed = true;

            if (isButtonReleased(Buttons.B) || isKeyReleased(Keys.A))
                Controls.clawReleased = true;

            if (isButtonHeld(Buttons.B) || isKeyHeld(Keys.A))
                Controls.clawState = true;
        }

        public void updateSelect()
        {
            Controls.selectPressed = false;
            Controls.selectReleased = false;
            Controls.selectState = false;

            if (isButtonPressed(Buttons.A) || isKeyPressed(Keys.Space))
                Controls.selectPressed = true;

            if (isButtonReleased(Buttons.A) || isKeyReleased(Keys.Space))
                Controls.selectReleased = true;

            if (isButtonHeld(Buttons.A) || isKeyHeld(Keys.Space))
                Controls.selectState = true;
        }

        public void updateLeft()
        {
            Controls.leftState = false;
            Controls.leftPressed = false;
            Controls.leftReleased = false;

            if (currentPadState.DPad.Left == ButtonState.Pressed || currentPadState.ThumbSticks.Left.X < -stickMinMovement || isKeyHeld(Keys.Left))
                Controls.leftState = true;

            if (currentPadState.DPad.Left != ButtonState.Pressed && previousPadState.DPad.Left == ButtonState.Pressed || isKeyReleased(Keys.Left))
                Controls.leftReleased = true;

            if (currentPadState.DPad.Left == ButtonState.Pressed && previousPadState.DPad.Left != ButtonState.Pressed || isKeyPressed(Keys.Left))
                Controls.leftPressed = true;
        }

        public void updateRight()
        {
            Controls.rightState = false;
            Controls.rightPressed = false;
            Controls.rightReleased = false;

            if (currentPadState.DPad.Right == ButtonState.Pressed || currentPadState.ThumbSticks.Left.X > stickMinMovement || isKeyHeld(Keys.Right))
                Controls.rightState = true;

            if (currentPadState.DPad.Right != ButtonState.Pressed && previousPadState.DPad.Right == ButtonState.Pressed || isKeyReleased(Keys.Right))
                Controls.rightReleased = true;

            if (currentPadState.DPad.Right == ButtonState.Pressed && previousPadState.DPad.Right != ButtonState.Pressed || isKeyPressed(Keys.Right))
                Controls.rightPressed = true;
        }

        public void updateUp()
        {
            Controls.upState = false;
            Controls.upPressed = false;
            Controls.upReleased = false;

            if (currentPadState.DPad.Up == ButtonState.Pressed || currentPadState.ThumbSticks.Left.Y < -stickMinMovement || isKeyHeld(Keys.Up))
                Controls.upState = true;

            if (currentPadState.DPad.Up != ButtonState.Pressed && previousPadState.DPad.Up == ButtonState.Pressed || isKeyReleased(Keys.Up))
                Controls.upReleased = true;

            if (currentPadState.DPad.Up == ButtonState.Pressed && previousPadState.DPad.Up != ButtonState.Pressed || isKeyPressed(Keys.Up))
                Controls.upPressed = true;
        }

        public void updateDown()
        {
            Controls.downState = false;
            Controls.downPressed = false;
            Controls.downReleased = false;

            if (currentPadState.DPad.Down == ButtonState.Pressed || currentPadState.ThumbSticks.Left.Y > stickMinMovement || isKeyHeld(Keys.Down))
                Controls.downState = true;

            if (currentPadState.DPad.Down != ButtonState.Pressed && previousPadState.DPad.Down == ButtonState.Pressed || isKeyReleased(Keys.Down))
                Controls.downReleased = true;

            if (currentPadState.DPad.Down == ButtonState.Pressed && previousPadState.DPad.Down != ButtonState.Pressed || isKeyPressed(Keys.Down))
                Controls.downPressed = true;
        }

        private bool isButtonPressed(Buttons Button)
        {
            if (currentPadState.IsButtonDown(Button) && !(previousPadState.IsButtonDown(Button)))
                return true; ;
            return false;
        }

        private bool isButtonHeld(Buttons Button)
        {
            if (currentPadState.IsButtonDown(Button))
                return true;
            return false;
        }

        private bool isButtonReleased(Buttons Button)
        {
            if (!currentPadState.IsButtonDown(Button) && (previousPadState.IsButtonDown(Button)))
                return true;
            return false;
        }

        private bool isKeyPressed(Keys key)
        {
            if (currentKeyState.IsKeyDown(key) && !(previousKeyState.IsKeyDown(key)))
                return true; ;
            return false;
        }

        private bool isKeyHeld(Keys key)
        {
            if (currentKeyState.IsKeyDown(key))
                return true;
            return false;
        }

        private bool isKeyReleased(Keys key)
        {
            if (!currentKeyState.IsKeyDown(key) && (previousKeyState.IsKeyDown(key)))
                return true;
            return false;
        }

    }
}
