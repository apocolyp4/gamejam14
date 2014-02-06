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

        public void Draw()
        {
            DrawObjects();
            DrawUI();
            if (ScreenHandler.NextScreen != null)
            {
                ScreenHandler.NextScreen.Draw();
            }

        }

        public virtual void UpdateObject() { }
        public virtual void UpdateInput() { }
        public virtual void UpdateUI() { }
        public virtual void DrawObjects() { }
        public virtual void DrawUI() { }

        public abstract GameState ExitState();
    }
}
