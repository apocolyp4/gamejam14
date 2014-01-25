using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace AssWhipSoftware
{
    public class PauseScreen : Screen
    {
        public override bool isLive
        {
            get { return false; }
        }
        public override void Update()
        {
            if (InputHandler.NextEvent != null)
            {
                switch (InputHandler.NextEvent.State)
                {
                    case InputState.PAUSE:
                        ScreenHandler.RemoveScreen(this);
                        break;
                }
                InputHandler.RemoveEvent(InputHandler.NextEvent);
            }
        }

        public override void Draw(SpriteBatch SpriteBatch, ContentManager Content)
        {
            SpriteBatch.Begin();
            SpriteFont font = Content.Load<SpriteFont>("SpriteFont1");
            SpriteBatch.DrawString(font, "Pause", new Vector2(240, 240), Color.White);
            SpriteBatch.End();
        }
    }
}
