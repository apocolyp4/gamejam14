using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace AssWhipSoftware
{
    public class PauseScreen : Screen
    {
        GamePadState padState1 = GamePad.GetState(PlayerIndex.One);
        GamePadState previousState;
        public override bool isLive
        {
            get { return false; }
        }
        public override void Update()
        {
            previousState = padState1;
            padState1 = GamePad.GetState(PlayerIndex.One);
            if (padState1.IsButtonDown(Buttons.Start) && !padState1.IsButtonDown(Buttons.Start))
            {
                ScreenHandler.RemoveScreen(this);
            }
        }

        public override void Draw()
        {
            Settings.SpriteBatch.Begin();
            SpriteFont font = Settings.Content.Load<SpriteFont>("SpriteFont1");
            Settings.SpriteBatch.DrawString(font, "Pause", new Vector2(240, 240), Color.White);
            Settings.SpriteBatch.End();
        }
    }
}
