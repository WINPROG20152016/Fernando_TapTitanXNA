using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA_MichaelFernando
{
    public class Level
    {
        public static int windowWidth = 1024;
        public static int windowHeight = 768;
        ContentManager content;
        Texture2D background;
       
        public MouseState mouseState;
        public MouseState oldMouseState;
        bool mpressed, prev_mpressed = false;
        int mouseX, mouseY;

        Hero hero;
        Game1 game1;
        SpriteFont damageStringFont;
        int damageNumber = 0;
        int exitcheck = 0;
        Button playButton;
        Button attackButton;
        Button ad;

        public Level(ContentManager content, Game1 game1)
        {
            this.content = content;
            this.game1 = game1;
            hero = new Hero(content, this);

        }
        public void LoadContent()
        {
            background = content.Load<Texture2D>("universel");
            damageStringFont = content.Load<SpriteFont>("SpriteFont1");
            playButton = new Button(content, "button", new Vector2(500,150));
            attackButton = new Button(content, "button2", new Vector2(310,-10));
            ad = new Button(content, "ad", new Vector2(500, 500));
            hero.LoadContent();

        }
        public void Update(GameTime gameTime)
        {

            mouseState = Mouse.GetState();
            mouseX = mouseState.X;
            mouseY = mouseState.Y;
            prev_mpressed = mpressed;
            mpressed = mouseState.LeftButton == ButtonState.Pressed;
            hero.Update(gameTime);

            oldMouseState = mouseState;

            
            if (attackButton.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
            {
                damageNumber += 10;
            }
            if (damageNumber == 110)
            {
                game1.Exit();
            }    
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 vect = new Vector2(256, 250);
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            
            hero.Draw(gameTime, spriteBatch);
            
            spriteBatch.DrawString(damageStringFont, "Ayy Lmeo", Vector2.Zero, Color.Violet);
            spriteBatch.DrawString(damageStringFont, "Ayy Lme", Vector2.Zero, Color.Indigo);
            spriteBatch.DrawString(damageStringFont, "Ayy Lm", Vector2.Zero, Color.Blue);
            spriteBatch.DrawString(damageStringFont, "Ayy L", Vector2.Zero, Color.Green);
            spriteBatch.DrawString(damageStringFont, "Ayy", Vector2.Zero, Color.Yellow);
            spriteBatch.DrawString(damageStringFont, "Ay", Vector2.Zero, Color.Orange);
            spriteBatch.DrawString(damageStringFont, "A", Vector2.Zero, Color.Red);
            spriteBatch.DrawString(damageStringFont, "-$ " + damageNumber, new Vector2(250,250), Color.Red);
            playButton.Draw(gameTime, spriteBatch);
            attackButton.Draw(gameTime, spriteBatch);
            ad.Draw(gameTime, spriteBatch);
            if (damageNumber == 100)
            {
                spriteBatch.DrawString(damageStringFont, "Ayy Lme u broke", new Vector2(500, 500), Color.Violet);
            }

        }
    }
}
