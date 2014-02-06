using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AssWhipSoftware
{
    public class MessageBox : Screen
    {
        private Texture2D Texture;
        private string Message;
        public override bool isLive
        {
	        get 
	        { 
		        return true;
            }
        }
        public MessageBox(string Message)
        {
            Texture = Settings.Content.Load<Texture2D>("menubox");   
        }
        public override void Update()
        {
            if (InputHandler.NextEvent != null)
            {
                if (InputHandler.NextEvent.State == InputState.JUMP)
                    InputHandler.RemoveEvent(InputHandler.NextEvent);
            }
        }

        public override void Draw()
        {
            Settings.SpriteBatch.Draw(Texture, new Rectangle (0,0, 250, 150), Color.White);
            Settings.SpriteBatch.DrawString(Settings.defaultFont, Message, new Vector2(10,10), Color.White);
        }
    }
}
