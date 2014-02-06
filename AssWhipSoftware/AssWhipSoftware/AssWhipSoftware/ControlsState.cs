using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AssWhipSoftware.Backend;

namespace AssWhipSoftware
{
    public class ControlsState : GameState
    {
        GamePadState padState1 = GamePad.GetState(PlayerIndex.One);
        GamePadState previousState;
        private bool isExiting;
        Texture2D background;
        public ControlsState()
        {
            background = Settings.Content.Load<Texture2D>("InstructionsScreen");
        }
        public override void UpdateInput()
        {
            previousState = padState1;
            padState1 = GamePad.GetState(PlayerIndex.One);
            if (padState1.IsButtonDown(Buttons.B))
            {
                isExiting = true;
            }
        }
        public override void DrawUI()
        {
            Settings.SpriteBatch.Begin();
            Settings.SpriteBatch.Draw(background, new Rectangle(0, 0, Settings.GraphicsDevice.Viewport.Width, Settings.GraphicsDevice.Viewport.Height), Color.White);
            Settings.SpriteBatch.End();
            //Input
        }
        public override GameState ExitState()
        {
            if (isExiting)
                return new MainMenu();
            return this;
        }
    }
}
