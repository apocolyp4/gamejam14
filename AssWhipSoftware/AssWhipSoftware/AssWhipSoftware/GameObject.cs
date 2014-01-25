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
        private Vector2 position;
        private Texture2D texture;
        private float scale;
        private float angle;
        private Vector2 velocity; 
        
        public Texture2D getTexture()
        {
            return texture;
        }

        public void setTexture(Texture2D newTexture)
        {
            texture = newTexture;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public float getX()
        {
            return position.X;
        }

        public void setX(float newX)
        {
            position.X = newX;
        }

        public float getY()
        {
            return position.Y;
        }

        public void setY(float newY)
        {
            position.Y = newY;
        }

        public float getWidth()
        {
            return texture.Width;
        }

        public float getHeight()
        {
            return texture.Height;
        }

        public float getScale()
        {
            return scale;
        }

        public void setScale(float newScale)
        {
            scale = newScale;
        }

        public float getAngle()
        {
            return angle;
        }

        public void setAngle(float newAngle)
        {
            angle = newAngle;
        }

        public Vector2 getVelocity()
        {
            return velocity;
        }

        public void setPosition(Vector2 newVelocity)
        {
            velocity = newVelocity;
        }
    }
}
