using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AssWhipSoftware
{
    public class UIElement
    {
        private Texture2D texture;
        private float x, y;
        public Texture2D Texture { get { return texture; } set { texture = value; } }
        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } }
        public Vector2 Position { get { return new Vector2(X, Y); } }
        public float Height { get { return Texture.Height; } }
        public float Width { get { return Texture.Width; } }
        public UIElement(Texture2D Texture, float X, float Y)
        {
            texture = Texture;
            
            x = X;
            y = Y;
        }
    }
}
