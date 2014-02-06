using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using AssWhipSoftware.Backend;

namespace AssWhipSoftware.Backend
{
    public class GamePlay : GameState
    {
        KeyboardState keyboard = Keyboard.GetState();
        KeyboardState previousKeyboard = Keyboard.GetState();
        Player player1 = new Player();
        Level gameLevel = new Level();
        GamePadState padState1 = GamePad.GetState(PlayerIndex.One);
        GamePadState previousState;
        Texture2D gui_A, gui_B, health, halfHeart, emptyHeart, energy, halfEnergy, noEnergy;
        Texture2D[] keys, missingKeys;
        int life, playerEnergy;
        bool[] keysFound;
        bool playerIsGood = true;
        UIElement playerForm;
        UIElement[] uiHealth, uiEnergy, uiKeys;
        List<UIElement> UIList = new List<UIElement>();
        //Song music = Settings.Content.Load<Song>("BlackVortex");

        public GamePlay()
        {
            player1.create();

  	        gui_A = Settings.Content.Load<Texture2D>("Portrait-11");
            gui_B = Settings.Content.Load<Texture2D>("Portrait-10");
            health = Settings.Content.Load<Texture2D>("UI-15");
            halfHeart = Settings.Content.Load<Texture2D>("UI-16");
            emptyHeart = Settings.Content.Load<Texture2D>("UI-17");
            energy = Settings.Content.Load<Texture2D>("UI-12");
            halfEnergy = Settings.Content.Load<Texture2D>("UI-13");
            noEnergy = Settings.Content.Load<Texture2D>("UI-14");
            keys = new Texture2D[5];
            keys[0] = Settings.Content.Load<Texture2D>("UI-18");
            keys[1] = Settings.Content.Load<Texture2D>("UI-19");
            keys[2] = Settings.Content.Load<Texture2D>("UI-20");
            keys[3] = Settings.Content.Load<Texture2D>("UI-21");
            keys[4] = Settings.Content.Load<Texture2D>("UI-22");
            missingKeys = new Texture2D[5];
            missingKeys[0] = Settings.Content.Load<Texture2D>("UI-23");
            missingKeys[1] = Settings.Content.Load<Texture2D>("UI-24");
            missingKeys[2] = Settings.Content.Load<Texture2D>("UI-25");
            missingKeys[3] = Settings.Content.Load<Texture2D>("UI-26");
            missingKeys[4] = Settings.Content.Load<Texture2D>("UI-27");
	        life = 10;
            playerEnergy = 10;
            keysFound = new bool[5];
            keysFound[0] = false;
            keysFound[1] = false;
            keysFound[2] = false;
            keysFound[3] = false;
            keysFound[4] = false;
            playerForm = new UIElement(gui_A, 16, 6);
            UIList.Add(playerForm);
            uiHealth = new UIElement[5];
            uiEnergy = new UIElement[5];
            uiKeys = new UIElement[5];
            int x = 120;
            for (int i = 0; i < 5; i++)
            {
                uiHealth[i] = new UIElement(health, x, 16);
                x += 16;
                UIList.Add(uiHealth[i]);
            }
            x = 120;
            for (int i = 0; i < 5; i++)
            {
                uiEnergy[i] = new UIElement(energy, x, 36);
                x += 16;
                UIList.Add(uiEnergy[i]);
            }
            x = 120;
            for (int i = 0; i < 5; i++)
            {
                uiKeys[i] = new UIElement(missingKeys[i], x, 56);
                x += 16;
                UIList.Add(uiKeys[i]);
            }


            gameLevel.initLevel();
            gameLevel.load("Level0.txt");

            //MediaPlayer.Volume = 1.0f;
            //MediaPlayer.Play(music);
   

        }

        public override void UpdateObject()
        {
            movePlayerIfPossible();
            player1.OnGround = isOnFirmGround(player1.Bounds);
            player1.HitHead = hitHead(player1.Bounds);
            player1.HitLeft = hitLeft(player1.Bounds);
            player1.HitRight = hitRight(player1.Bounds);
            player1.update();
            if (player1.LoadLevel)
            {
                player1.setPosition(230, 0);
                gameLevel.load("Level" + Settings.levelNumber.ToString() + ".txt");
            }
        }

        public void movePlayerIfPossible()
        {
            float oldX = player1.X;
            float oldY = player1.Y;
            player1.applyGravity();
            player1.updatePosition();
            if (!gameLevel.hasRoomForRectangle(player1.Bounds))
            {
                Vector2 oldPosition = new Vector2(oldX, oldY);
                Vector2 position = new Vector2(player1.X, player1.Y);
                position = whereCanIGetTo(oldPosition, position, player1.Bounds);
                player1.X = position.X;
                player1.Y = position.Y;   
            }
        }

        private Rectangle createRectangleAtPosition(Vector2 positionToTry, int width, int height)
        {
            return new Rectangle((int)positionToTry.X, (int)positionToTry.Y, width, height);
        }

        public Vector2 whereCanIGetTo(Vector2 originalPosition, Vector2 destination, Rectangle boundingRectangle)
        {
            Vector2 movementToTry = destination - originalPosition;
            Vector2 furthestAvailableLocationSoFar = originalPosition;
            int numberOfStepsToBreakMovementInto = (int)(movementToTry.Length() * 2) + 1;
            Vector2 oneStep = movementToTry / numberOfStepsToBreakMovementInto;

            for (int i = 1; i <= numberOfStepsToBreakMovementInto; i++)
            {
                Vector2 positionToTry = originalPosition + oneStep * i;
                Rectangle newBoundary = createRectangleAtPosition(positionToTry, boundingRectangle.Width, boundingRectangle.Height);
                if (gameLevel.hasRoomForRectangle(newBoundary)) { furthestAvailableLocationSoFar = positionToTry; }
                else
                {
                    bool isDiagonalMove = movementToTry.X != 0 && movementToTry.Y != 0;
                    if (isDiagonalMove)
                    {
                        int stepsLeft = numberOfStepsToBreakMovementInto - (i - 1);
                        Vector2 remainingHorizontalMovement = oneStep.X * Vector2.UnitX * stepsLeft;
                        Vector2 finalPositionIfMovingHorizontally = furthestAvailableLocationSoFar + remainingHorizontalMovement;
                        furthestAvailableLocationSoFar = whereCanIGetTo(furthestAvailableLocationSoFar, finalPositionIfMovingHorizontally, boundingRectangle);
                        Vector2 remainingVerticalMovement = oneStep.Y * Vector2.UnitY * stepsLeft;
                        Vector2 finalPositionIfMovingVertically = furthestAvailableLocationSoFar + remainingVerticalMovement;
                        furthestAvailableLocationSoFar = whereCanIGetTo(furthestAvailableLocationSoFar, finalPositionIfMovingVertically, boundingRectangle);
                    }
                    break;
                }
            }
            return furthestAvailableLocationSoFar;
        }

        public bool isOnFirmGround(Rectangle rectangleToCheck)
        {
            Rectangle onePixelLower = rectangleToCheck;
            onePixelLower.Offset(0, 1);
            return !gameLevel.hasRoomForRectangle(onePixelLower);
        }

        public bool hitHead(Rectangle rectangleToCheck)
        {
            Rectangle onePixelHigher = rectangleToCheck;
            onePixelHigher.Offset(0, -1);
            return !gameLevel.hasRoomForRectangle(onePixelHigher);
        }

        public bool hitLeft(Rectangle rectangleToCheck)
        {
            Rectangle onePixel = rectangleToCheck;
            onePixel.Offset(-1, 0);
            return !gameLevel.hasRoomForRectangle(onePixel);
        }

        public bool hitRight(Rectangle rectangleToCheck)
        {
            Rectangle onePixel = rectangleToCheck;
            onePixel.Offset(1, 0);
            return !gameLevel.hasRoomForRectangle(onePixel);
        }

        public override void UpdateInput()
        {
            previousKeyboard = keyboard;
            keyboard = Keyboard.GetState();
            previousState = padState1;
            padState1 = GamePad.GetState(PlayerIndex.One);
            if (Controls.leftState)
            {
                player1.accelerateX(-0.5f);
                player1.Direction = "left";
            }
            if (Controls.rightState)
            {
                player1.accelerateX(0.5f);
                player1.Direction = "right";
            }

            if (Controls.jumpReleased)// || keyboard.IsKeyUp(Microsoft.Xna.Framework.Input.Keys.Space))
            {
                player1.JumpReleased = true;
            }

            if (Controls.clawPressed)
            {
                player1.claw();
            }

            if (Controls.arseWhipPressed)
            {
                player1.ArseWhip();
            }

            if (Controls.bitePressed)
            {
                player1.bite();
            }
            
            if (Controls.jumpState)
            {

                if (player1.OnGround && Controls.jumpPressed)
                {
                    player1.JumpCounter = 10;
                    player1.Jumped = true;
                    player1.JumpReleased = false;
                }
                
                if(player1.Jumped && !player1.JumpReleased)
                {
                    player1.YVel = -12f;
                    player1.JumpCounter -= 1;
                    if (player1.JumpCounter < 1)
                    {
                        player1.Jumped = false;
                    }
                }
            }


            if (Controls.upPressed)
            {
                if (gameLevel.IsEvil) 
                {
                    gameLevel.IsEvil = false;
                }
                else
                {
                    gameLevel.IsEvil = true;
                }
            }
             

            if (padState1.Buttons.Start == ButtonState.Pressed && !previousState.IsButtonDown(Buttons.A))
            {
                ScreenHandler.NextScreen = new PauseScreen();
            }
        }

        public override void UpdateUI()
        {
            for (int i = 0; i < 5; i++)
            {
                if (keysFound[i])
                    uiKeys[i].Texture = keys[i];
            }
            switch (life)
            {
                case 10:
                    uiHealth[0].Texture = health;
                    uiHealth[1].Texture = health;
                    uiHealth[2].Texture = health;
                    uiHealth[3].Texture = health;
                    uiHealth[4].Texture = health;
                    break;
                case 9:
                    uiHealth[0].Texture = health;
                    uiHealth[1].Texture = health;
                    uiHealth[2].Texture = health;
                    uiHealth[3].Texture = health;
                    uiHealth[4].Texture = halfHeart;
                    break;
                case 8:
                    uiHealth[0].Texture = health;
                    uiHealth[1].Texture = health;
                    uiHealth[2].Texture = health;
                    uiHealth[3].Texture = health;
                    uiHealth[4].Texture = emptyHeart;
                    break;
                case 7:
                    uiHealth[0].Texture = health;
                    uiHealth[1].Texture = health;
                    uiHealth[2].Texture = health;
                    uiHealth[3].Texture = halfHeart;
                    uiHealth[4].Texture = emptyHeart;
                    break;
                case 6:
                    uiHealth[0].Texture = health;
                    uiHealth[1].Texture = health;
                    uiHealth[2].Texture = health;
                    uiHealth[3].Texture = emptyHeart;
                    uiHealth[4].Texture = emptyHeart;
                    break;
                case 5:
                    uiHealth[0].Texture = health;
                    uiHealth[1].Texture = health;
                    uiHealth[2].Texture = halfHeart;
                    uiHealth[3].Texture = emptyHeart;
                    uiHealth[4].Texture = emptyHeart;
                    break;
                case 4:
                    uiHealth[0].Texture = health;
                    uiHealth[1].Texture = health;
                    uiHealth[2].Texture = emptyHeart;
                    uiHealth[3].Texture = emptyHeart;
                    uiHealth[4].Texture = emptyHeart;
                    break;
                case 3:
                    uiHealth[0].Texture = health;
                    uiHealth[1].Texture = halfHeart;
                    uiHealth[2].Texture = emptyHeart;
                    uiHealth[3].Texture = emptyHeart;
                    uiHealth[4].Texture = emptyHeart;
                    break;
                case 2:
                    uiHealth[0].Texture = health;
                    uiHealth[1].Texture = emptyHeart;
                    uiHealth[2].Texture = emptyHeart;
                    uiHealth[3].Texture = emptyHeart;
                    uiHealth[4].Texture = emptyHeart;
                    break;
                case 1:
                    uiHealth[0].Texture = halfHeart;
                    uiHealth[1].Texture = emptyHeart;
                    uiHealth[2].Texture = emptyHeart;
                    uiHealth[3].Texture = emptyHeart;
                    uiHealth[4].Texture = emptyHeart;
                    break;
                case 0:
                    uiHealth[0].Texture = emptyHeart;
                    uiHealth[1].Texture = emptyHeart;
                    uiHealth[2].Texture = emptyHeart;
                    uiHealth[3].Texture = emptyHeart;
                    uiHealth[4].Texture = emptyHeart;
                    break;
            }
            switch (playerEnergy)
            {
                case 10:
                    uiEnergy[0].Texture = energy;
                    uiEnergy[1].Texture = energy;
                    uiEnergy[2].Texture = energy;
                    uiEnergy[3].Texture = energy;
                    uiEnergy[4].Texture = energy;
                    break;
                case 9:
                    uiEnergy[0].Texture = energy;
                    uiEnergy[1].Texture = energy;
                    uiEnergy[2].Texture = energy;
                    uiEnergy[3].Texture = energy;
                    uiEnergy[4].Texture = halfEnergy;
                    break;
                case 8:
                    uiEnergy[0].Texture = energy;
                    uiEnergy[1].Texture = energy;
                    uiEnergy[2].Texture = energy;
                    uiEnergy[3].Texture = energy;
                    uiEnergy[4].Texture = noEnergy;
                    break;
                case 7:
                    uiEnergy[0].Texture = energy;
                    uiEnergy[1].Texture = energy;
                    uiEnergy[2].Texture = energy;
                    uiEnergy[3].Texture = halfEnergy;
                    uiEnergy[4].Texture = noEnergy;
                    break;
                case 6:
                    uiEnergy[0].Texture = energy;
                    uiEnergy[1].Texture = energy;
                    uiEnergy[2].Texture = energy;
                    uiEnergy[3].Texture = noEnergy;
                    uiEnergy[4].Texture = noEnergy;
                    break;
                case 5:
                    uiEnergy[0].Texture = energy;
                    uiEnergy[1].Texture = energy;
                    uiEnergy[2].Texture = halfEnergy;
                    uiEnergy[3].Texture = noEnergy;
                    uiEnergy[4].Texture = noEnergy;
                    break;
                case 4:
                    uiEnergy[0].Texture = energy;
                    uiEnergy[1].Texture = energy;
                    uiEnergy[2].Texture = noEnergy;
                    uiEnergy[3].Texture = noEnergy;
                    uiEnergy[4].Texture = noEnergy;
                    break;
                case 3:
                    uiEnergy[0].Texture = energy;
                    uiEnergy[1].Texture = halfEnergy;
                    uiEnergy[2].Texture = noEnergy;
                    uiEnergy[3].Texture = noEnergy;
                    uiEnergy[4].Texture = noEnergy;
                    break;
                case 2:
                    uiEnergy[0].Texture = energy;
                    uiEnergy[1].Texture = noEnergy;
                    uiEnergy[2].Texture = noEnergy;
                    uiEnergy[3].Texture = noEnergy;
                    uiEnergy[4].Texture = noEnergy;
                    break;
                case 1:
                    uiEnergy[0].Texture = halfEnergy;
                    uiEnergy[1].Texture = noEnergy;
                    uiEnergy[2].Texture = noEnergy;
                    uiEnergy[3].Texture = noEnergy;
                    uiEnergy[4].Texture = noEnergy;
                    break;
                case 0:
                    uiEnergy[0].Texture = noEnergy;
                    uiEnergy[1].Texture = noEnergy;
                    uiEnergy[2].Texture = noEnergy;
                    uiEnergy[3].Texture = noEnergy;
                    uiEnergy[4].Texture = noEnergy;
                    break;
            }            
        }

        public override void DrawObjects()
        {
            Settings.SpriteBatch.Begin();
            gameLevel.draw();
            player1.draw();
            Settings.SpriteBatch.End();
        }

        public override void DrawUI()
        {
            Settings.SpriteBatch.Begin();
            foreach (UIElement ui in UIList)
            {
                if (ui == playerForm)
                    Settings.SpriteBatch.Draw(ui.Texture, new Rectangle((int)ui.X, (int)ui.Y, (int)ui.Width, (int)ui.Height), Color.White);
                else
                    Settings.SpriteBatch.Draw(ui.Texture, new Rectangle((int)ui.X, (int)ui.Y, (int)ui.Width / 2, (int)ui.Height / 2), Color.White);
            }
            Settings.SpriteBatch.End();
            //Settings.SpriteBatch.Draw
        }

        public override GameState ExitState()
        {
            return this;
        }
    }
}
