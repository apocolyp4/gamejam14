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
    public abstract class GameObject
    {
        private string status;
        private int health;
        private bool jumped;
        private int jumpCounter; 
        private bool jumpReleased;
        private bool onGround;
        private bool hitHead;
        private bool hitLeft;
        private bool hitRight;
        private bool isBlocked;
        private float x;
        private float y;
        private float xVel;
        private float yVel;
        private float maxVelX;
        private float maxVelY;
        private float xAccel;
        private Texture2D texture;
        private float scale;
        private float angle;
        private string type;
        private string direction;
        private Texture2D drawTexture;
        private bool isEvil;
        public int Health { get { return health; } }

        public Texture2D Texture
        {
            get {return texture;}
            set {texture = value;}
        }

        public Texture2D DrawTexture
        {
            get { return drawTexture; }
            set { drawTexture = value; }
        }

        public string Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public float XAccel
        {
            get { return xAccel; }
            set { xAccel = value; }
        }

        public float X
        {
            get {return x;}
            set {x = value; }
        }

        public float Y
        {
            get {return y;}
            set {y = value;}
        }


        public float MaxVelX
        {
            get { return maxVelX; }
            set { maxVelX = value; }
        }

        public float MaxVelY
        {
            get { return maxVelY; }
            set { maxVelY = value; }
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
            get { return yVel; }
            set { yVel = value; }
        }


        public bool OnGround
        {
            get { return onGround; }
            set { onGround = value; }
        }

        public bool IsEvil
        {
            get { return isEvil; }
            set { isEvil = value; }
        }

        public bool Jumped
        {
            get { return jumped; }
            set { jumped = value; }
        }


        public int JumpCounter
        {
            get { return jumpCounter; }
            set { jumpCounter = value; }
        }


        public bool JumpReleased
        {
            get { return jumpReleased; }
            set { jumpReleased = value; }
        }

        public bool HitHead
        {
            get { return hitHead; }
            set { hitHead = value; }
        }

        public bool HitLeft
        {
            get { return hitLeft; }
            set { hitLeft= value; }
        }

        public bool HitRight
        {
            get { return hitRight; }
            set { hitRight = value; }
        }

        public bool IsBlocked
        {
            get { return isBlocked; }
            set { isBlocked = value; }
        }

        public Rectangle Bounds
        {
            get { return new Rectangle((int)x, (int)y, texture.Width, texture.Height); }
        }

        public void setPosition(float newX, float newY)
        {
            x = newX;
            y = newY;
        }

        public void updatePosition()
        {
            x += xVel;
            y += yVel;
        }

        public void applyGravity()
        {
            float maxGravity = 14.0f;
            float gravity = 1.5f;
            yVel += gravity;
            if (yVel > maxGravity)
            {
                yVel = maxGravity;
            }

        }

        public void accelerateX(float accellX)
        {
            xVel += accellX;
            if (xVel > maxVelX)
            {
                xVel = maxVelX;
            }
            if (xVel < maxVelX * -1)
            {
                xVel = maxVelX * -1;
            }
        }
        public void applyFriction()
        {
            float friction = 0.4f;
            if (xVel > 0)
            {
                xVel -= friction;
                if (xVel < 0)
                {
                    xVel = 0;
                }
            }
            if (xVel < 0)
            {
                xVel += friction;
                if (xVel > 0)
                {
                    xVel = 0;
                }
            }
        }
    }
}
