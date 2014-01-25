using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using AssWhipSoftware;
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
            //throw new NotImplementedException();
        }

        public override void UpdateInput()
        {

        }

        public override void UpdateUI()
        {
            //throw new NotImplementedException();
        }

        public override void DrawObjects(SpriteBatch SpriteBatch, ContentManager Content)
        {
            //throw new NotImplementedException();
        }

        public override void DrawUI(SpriteBatch SpriteBatch, ContentManager Content)
        {
            //throw new NotImplementedException();
        }

        public override GameState ExitState()
        {
            return this;
        }
    }
}
