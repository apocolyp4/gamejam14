using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace AssWhipSoftware.Backend
{
    public class MainMenu : GameState
    {
        GamePadState padState1 = GamePad.GetState(PlayerIndex.One);
        GamePadState previousState;
        private int iterator;
        private List<string> MenuOptions = new List<string>();
        private GameState nextState = null;
        SpriteFont font;
        Texture2D texture, background, credits, creditsSelected, newgame, newgameSelected, options, optionsSelected;
        private int Iterator
        {
            get { return iterator; }
            set
            {
                iterator = value;
                if (iterator >= MenuOptions.Count)
                    iterator = MenuOptions.Count - 1;
                if (iterator <= 0)
                    iterator = 0;
            }
        }
        public MainMenu()
        {
            MenuOptions.Add("Gameplay");
            MenuOptions.Add("Options");
            MenuOptions.Add("Credits");
            font = Settings.Content.Load<SpriteFont>("SpriteFont1");
            texture = Settings.Content.Load<Texture2D>("menubox");
            background = Settings.Content.Load<Texture2D>("MenuBackground");
            credits = Settings.Content.Load<Texture2D>("CreditsDeSelect");
            creditsSelected = Settings.Content.Load<Texture2D>("CreditsSelect");
            newgame = Settings.Content.Load<Texture2D>("NewGameDeSelect");
            newgameSelected = Settings.Content.Load<Texture2D>("NewGameSelect");
            options = Settings.Content.Load<Texture2D>("InstructionsDeSelect");
            optionsSelected = Settings.Content.Load<Texture2D>("InstructionsSelect");
        }

        public override void UpdateInput()
        {
            if (Controls.rightPressed)
            {
                Iterator++;
            }
            if (Controls.leftPressed)
            {
                Iterator--;
            }

            if (Controls.selectPressed)
            {
                nextState = ObtainState();
            }
        }

        public override void DrawUI()
        {

            Settings.SpriteBatch.Begin();
            Settings.SpriteBatch.Draw(background, new Rectangle(0, 0, (int)Settings.GraphicsDevice.Viewport.Width, (int)Settings.GraphicsDevice.Viewport.Height), Color.White);
            Texture2D game;
            Texture2D credit;
            if (Iterator == 2)
            {
                Settings.SpriteBatch.Draw(newgame, new Rectangle(20, 350, 250, 120), Color.White);
                Settings.SpriteBatch.Draw(options, new Rectangle((int)(Settings.GraphicsDevice.Viewport.Width / 2 - 115), 350,
                    250, 120), Color.White);
                Settings.SpriteBatch.Draw(creditsSelected, new Rectangle((int)(Settings.GraphicsDevice.Viewport.Width - 250), 350, 250, 120), Color.White);
            }
            else if (Iterator == 1)
            {
                Settings.SpriteBatch.Draw(newgame, new Rectangle(20, 350, 250, 120), Color.White);
                Settings.SpriteBatch.Draw(optionsSelected, new Rectangle((int)(Settings.GraphicsDevice.Viewport.Width / 2 - 115), 350,
                    250, 120), Color.White);
                Settings.SpriteBatch.Draw(credits, new Rectangle((int)(Settings.GraphicsDevice.Viewport.Width - 250),
                    350, 250, 120), Color.White);
            }
            else if (Iterator == 0)
            {
                Settings.SpriteBatch.Draw(newgameSelected, new Rectangle(20, 350, 250, 120), Color.White);
                Settings.SpriteBatch.Draw(options, new Rectangle((int)(Settings.GraphicsDevice.Viewport.Width / 2 - 115), 350,
                    250, 120), Color.White);
                Settings.SpriteBatch.Draw(credits, new Rectangle((int)(Settings.GraphicsDevice.Viewport.Width - 250),
                    350, 250, 120), Color.White);
            }
            //Settings.SpriteBatch.Draw
            /*int y = 260;
            Settings.SpriteBatch.Draw(texture, new Rectangle(300, 170, 297, 173), Color.White);
            Settings.SpriteBatch.DrawString(font, "Main Menu", new Vector2(330, 200), Color.Black);
            Color colour = Color.White;
            for (int i = 0; i < MenuOptions.Count; i++)
            {
                colour = Color.Black;
                if (i == Iterator)
                {
                    colour = Color.Blue;
                    Settings.SpriteBatch.DrawString(font, "<", new Vector2(560, y), Color.Black);
                }
                Settings.SpriteBatch.DrawString(font, MenuOptions[i].ToString(), new Vector2(330, y), colour);

                y += 20;
            }*/
            Settings.SpriteBatch.End();

        }
        private GameState ObtainState()
        {
            switch (Iterator)
            {
                case 0:
                    return new GamePlay();
                case 1:
                    return new ControlsState();
                default:
                    return new Credits();
            }
        }
        public override GameState ExitState()
        {
            if (nextState != null)
                return nextState;
            return this;
        }
    }
}
