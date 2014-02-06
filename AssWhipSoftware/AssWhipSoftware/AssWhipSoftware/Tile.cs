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
    public class Tile : GameObject
    {
        private Texture2D evilTexture;
		

        public Texture2D EvilTexture
        {
            get { return evilTexture; }
            set { evilTexture = value; }
        }

    }

}
