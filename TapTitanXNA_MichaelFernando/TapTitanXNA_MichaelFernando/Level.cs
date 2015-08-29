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
        int damageInput = 0;
        int buttonCheck = 0;
        int oldDamageInput = 0;
        int trigger = 0;
        Button playButton;
        Button attackButton;
        Button ad;

        string time;

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
            playButton = new Button(content, "atkbutton", new Vector2(550,-10));
            attackButton = new Button(content, "atkbutton2", new Vector2(310,-10));
            ad = new Button(content, "loa", new Vector2(700, 450));
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
            time = gameTime.TotalGameTime.Seconds.ToString();
            if (trigger == 1)
            {
                if (damageInput == oldDamageInput)
                {

                }
                else
                {
                    trigger = 1;
                }
            }
            if (damageInput % 1 == 0 && trigger == 1)
            {
                damageNumber ++;
            }
            if (attackButton.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
            {
                damageNumber += 50;
                hero.attack();
                buttonCheck = 1;
            }
            if (damageNumber > 2550)
            {
                game1.Exit();
            }
            if (playButton.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
            {
                hero.attack();
                damageInput = gameTime.TotalGameTime.Seconds;
                oldDamageInput = damageInput;
                damageInput++;
                buttonCheck = 1;
                if (damageInput == oldDamageInput)
                {
                    
                }
                else
                {
                    trigger = 1;
                }
            }
            buttonCheck = 0;
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
            spriteBatch.DrawString(damageStringFont, "HP: " + (2500 - damageNumber), new Vector2(200,250), Color.Red);
            playButton.Draw(gameTime, spriteBatch);
            attackButton.Draw(gameTime, spriteBatch);
            ad.Draw(gameTime, spriteBatch);
            if (damageNumber >= 2500)
            {
                spriteBatch.DrawString(damageStringFont, "You Win", new Vector2(500, 350), Color.Violet);
            }
            if (trigger == 1)
            {
                spriteBatch.DrawString(damageStringFont, "BLEED", new Vector2(500,500), Color.Red);
            }
            //spriteBatch.DrawString(damageStringFont, time, new Vector2(0, 50), Color.White);

        }
    }
}
