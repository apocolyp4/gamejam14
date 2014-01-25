using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AssWhipSoftware
{
    abstract class GameObject
    {
        private float x;
        private float y;
        private float xVel;
        private float yVel;
        private Texture2D texture;
        private float scale;
        private float angle;
        private Vector2 velocity; 
        
        public Texture2D Texture
        {
            get {return texture;}
            set {texture = value;}
        }

        public float X
        {
            get {return x;}
            set {x = value; }
        }

        public float Y
        {
            get {return Y;}
            set {y = value;}
        }

        public float Width
        {
            get {return texture.Width;}
        }

        public float Height
        {
            get {return texture.Height;}
        }

        public float Scale
        {
            get {return scale;}
            set {scale = value;}
        }

        public float Angle
        {
            get {return angle;}
            set {angle = value; }
        }

        public float XVel
        {
            get { return xVel; }
            set { xVel = value; }
        }

        public float YVel
        {
            get { return YVel; }
            set { yVel = value; }
        }

    }
}
