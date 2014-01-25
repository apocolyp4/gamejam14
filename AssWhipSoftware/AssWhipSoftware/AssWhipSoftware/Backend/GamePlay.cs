using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using AssWhipSoftware.Backend;

namespace AssWhipSoftware.Backend
{
    public class GamePlay : GameState
    {

        public GamePlay()
        {
        }

        public override void UpdateObject()
        {
        }

        public override void UpdateInput()
        {
            if (InputHandler.NextEvent != null)
            {
                switch (InputHandler.NextEvent.State)
                {
                    case InputState.PAUSE:
                        ScreenHandler.NextScreen = new PauseScreen();
                        break;
                }
                InputHandler.RemoveEvent(InputHandler.NextEvent);
            }
        }

        public override void UpdateUI()
        {
            
        }

        public override void DrawObjects(SpriteBatch SpriteBatch, ContentManager Content)
        {

        }

        public override void DrawUI(SpriteBatch SpriteBatch, ContentManager Content)
        {
        }

        public override GameState ExitState()
        {
            return this;
        }
    }
}
