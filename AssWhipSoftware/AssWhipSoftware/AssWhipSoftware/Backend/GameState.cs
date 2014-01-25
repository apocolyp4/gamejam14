using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace AssWhipSoftware.Backend
{
    public abstract class GameState
    {
        public void Update()
        {
            if (ScreenHandler.NextScreen != null)
            {
                if (!ScreenHandler.NextScreen.isLive)
                {
                    ScreenHandler.NextScreen.Update();
                }
                else
                {
                    UpdateObject();
                    ScreenHandler.NextScreen.Update();
                    UpdateUI();
                }
            }
            else
            {
                UpdateObject();
                UpdateInput();
                UpdateUI();
            }
        }

        public void Draw(SpriteBatch SpriteBatch, ContentManager Content)
        {
            DrawObjects(SpriteBatch, Content);
            DrawUI(SpriteBatch, Content);
            if (ScreenHandler.NextScreen != null)
            {
                ScreenHandler.NextScreen.Draw(SpriteBatch, Content);
            }
        }

        public virtual void UpdateObject() { }
        public virtual void UpdateInput() { }
        public virtual void UpdateUI() { }
        public virtual void DrawObjects(SpriteBatch SpriteBatch, ContentManager Content) { }
        public virtual void DrawUI(SpriteBatch SpriteBatch, ContentManager Content) { }

        public abstract GameState ExitState();
    }
}
