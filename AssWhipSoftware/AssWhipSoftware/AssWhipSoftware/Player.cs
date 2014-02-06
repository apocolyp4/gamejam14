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
    class Player : GameObject
    {
        private Animation goodWalk = new Animation();
        private Animation goodJump = new Animation();
        private Animation badWalk = new Animation();
        private Animation badJump = new Animation();
        private Animation goodIdle = new Animation();
        private Animation badIdle = new Animation();
        private Animation goodArseWhip = new Animation();
        private Animation badArseWhip = new Animation();
        private Animation goodBite = new Animation();
        private Animation badBite = new Animation();
        private Animation goodClaw = new Animation();
        private Animation badClaw = new Animation();
        private bool loadLevel;
        private int atDoorCount;

        public void create()
        {
            loadLevel = false;
            IsEvil = false;
            Texture = Settings.Content.Load<Texture2D>("LionGoodWalk8");
            Status = "Idle";
            createAnimations();
            setPosition(230, 0);
            MaxVelX = 8.0f;
            XVel = 0;
            YVel = 0;
            Scale = 1;
            Jumped = false;
        }

        public void createAnimations()
        {
            goodWalk.Timer = 5;
            goodWalk.Loop = true;
            for (int i = 1; i < 9; i++)
            {
                goodWalk.addFrame("LionGoodWalk" + i.ToString());
            }

            goodJump.Timer = 5;
            goodJump.Loop = false;
            goodJump.addFrame("LionGoodJump2");


            badWalk.Timer = 5;
            badWalk.Loop = true;
            for (int i = 1; i < 9; i++)
            {
                badWalk.addFrame("LionBadWalk" + i.ToString());
            }

            badJump.Timer = 5;
            badJump.Loop = false;
            badJump.addFrame("LionBadJump2");

            goodIdle.Timer = 5;
            goodIdle.Loop = true;
            goodIdle.addFrame("LionGoodWalk8");

            badIdle.Timer = 5;
            badIdle.Loop = true;
            badIdle.addFrame("LionBadWalk8");

            goodArseWhip.Timer = 5;
            goodArseWhip.Loop = false;
            for (int i = 1; i < 4; i++)
            {
                goodArseWhip.addFrame("LionGoodArseWhip" + i.ToString());
            }

            badArseWhip.Timer = 5;
            badArseWhip.Loop = false;
            for (int i = 1; i < 4; i++)
            {
                badArseWhip.addFrame("LionBadArseWhip" + i.ToString());
            }


            goodClaw.Timer = 5;
            goodClaw.Loop = false;
            for (int i = 1; i < 4; i++)
            {
                goodClaw.addFrame("LionGoodClaw" + i.ToString());
            }

            badClaw.Timer = 5;
            badClaw.Loop = false;
            for (int i = 1; i < 4; i++)
            {
                badClaw.addFrame("LionBadClaw" + i.ToString());
            }

            goodBite.Timer = 5;
            goodBite.Loop = false;
            for (int i = 1; i < 5; i++)
            {
                goodBite.addFrame("LionGoodBite" + i.ToString());
            }

            badBite.Timer = 5;
            badBite.Loop = false;
            for (int i = 1; i < 5; i++)
            {
                badBite.addFrame("LionBadBite" + i.ToString());
            }

        }

        public void update()
        {
            if (Bounds.Intersects(Settings.goodDoor.Bounds) || Bounds.Intersects(Settings.badDoor.Bounds))
            {
                atDoorCount += 1;
            }
            else
            {
                atDoorCount = 0;
                loadLevel = false;
            }

            if (atDoorCount > 120)
            {
                if (Settings.levelNumber == 0)
                {
                    if (Settings.levelEnemies.Count > 0)
                    {
                        IsEvil = false;
                    }
                    else
                    {
                        IsEvil = true;
                    }

                    loadLevel = true;
                    
                }
                //atDoorCount = 0;
                Settings.levelNumber += 1;
                if (Settings.levelNumber > 3)
                {
                    Settings.levelNumber = 0;
                }
                
            }

            if (X > 425 && X < Settings.levelWidth - 425)
            {
                Settings.xLevelOffSet = X - 425;
            }

            if (Y > 240 && Y < Settings.levelHeight - 240) 
            {
                Settings.yLevelOffSet = Y - 240;
            }

            if (OnGround)
            {
                Jumped = false;
                applyFriction();
                YVel = 0;
            }
            if (HitHead)
            {
                YVel = 0;
                JumpReleased = true;
            }
            if (HitLeft && XVel < 0 || HitRight && XVel > 0)
            {
                XVel = 0;
            }

            updateAnimations();

        }

        public void claw()
        {
            Status = "Claw";
            if (!IsEvil)
            {
                goodClaw.start();
 
            }
            else
            {
                badClaw.start();
            }
        }

        public void bite()
        {
            Status = "Bite";
            if (!IsEvil)
            {
                goodBite.start();

            }
            else
            {
                badBite.start();
            }
        }

        public void ArseWhip()
        {
            Status = "ArseWhip";
            if (!IsEvil)
            {
                goodArseWhip.start();

            }
            else
            {
                badArseWhip.start();
            }
        }

        public void updateAnimations()
        {

            if (Status == "Idle")
            {

                if (XVel != 0 && !Jumped)
                {
                    if (!IsEvil)
                    {
                        goodWalk.update();
                        DrawTexture = goodWalk.Frame;
                    }
                    else
                    {
                        badWalk.update();
                        DrawTexture = badWalk.Frame;
                    }

                }
                else if (!JumpReleased && !OnGround)
                {
                    if (!IsEvil)
                    {
                        DrawTexture = goodJump.Frame;
                    }
                    else
                    {
                        DrawTexture = badJump.Frame;
                    }
                }
                else
                {
                    if (!IsEvil)
                    {
                        goodIdle.update();
                        DrawTexture = goodIdle.Frame;

                    }
                    else
                    {
                        badIdle.update();
                        DrawTexture = badIdle.Frame;
                    }
                }
            }
            else if (Status == "Claw")
            {
                if (!IsEvil)
                {
                    goodClaw.update();
                    DrawTexture = goodClaw.Frame;
                    if (goodClaw.Finished)
                    {
                        Status = "Idle";
                    }
                }
                else
                {
                    badClaw.update();
                    DrawTexture = badClaw.Frame;
                    if (badClaw.Finished)
                    {
                        Status = "Idle";
                    }
                }
            }
            else if (Status == "Bite")
            {
                if (!IsEvil)
                {
                    goodBite.update();
                    DrawTexture = goodBite.Frame;
                    if (goodBite.Finished)
                    {
                        Status = "Idle";
                    }
                }
                else
                {
                    badBite.update();
                    DrawTexture = badBite.Frame;
                    if (badBite.Finished)
                    {
                        Status = "Idle";
                    }
                }
            }
            else if (Status == "ArseWhip")
            {
                if (!IsEvil)
                {
                    goodArseWhip.update();
                    DrawTexture = goodArseWhip.Frame;
                    if (goodArseWhip.Finished)
                    {
                        Status = "Idle";
                    }
                }
                else
                {
                    badArseWhip.update();
                    DrawTexture = badArseWhip.Frame;
                    if (badArseWhip.Finished)
                    {
                        Status = "Idle";
                    }
                }
            }
        }

        
        public int AtDoorCount
        {
            get { return atDoorCount; }
            set { atDoorCount = value; }
        }

        public bool LoadLevel
        {
            get { return loadLevel; }
            set { loadLevel = value; }
        }

        public void draw()
        {
            if (Direction == "left")
            {
                Settings.SpriteBatch.Draw(DrawTexture, new Vector2(X - Settings.xLevelOffSet, Y - Settings.yLevelOffSet), null, Color.White, 0, new Vector2(0, 0), Scale, SpriteEffects.None, 0f);
            }
            else
            {
                Settings.SpriteBatch.Draw(DrawTexture, new Vector2(X - Settings.xLevelOffSet, Y - Settings.yLevelOffSet), null, Color.White, 0, new Vector2(0, 0), Scale, SpriteEffects.FlipHorizontally, 0f);
            }
        }
    }
}
