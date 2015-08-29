using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA_MichaelFernando
{
    public class Hero
    {
        #region Properties
        Texture2D player;
        Vector2 playerPosition;
        Vector2 heroPosition;
        ContentManager content;
        Level level;
        Animation idleAnimation;
        Animation supportAnimation;
        AnimationPlayer spritePlayer;
        AnimationPlayer spritePlayer1;
        Texture2D support;
        #endregion
        public static int windowWidth = 1024;
        public static int windowHeight = 768;
        int oldScrollWheelValue = 0;
        public Hero(ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;
        }
        public void LoadContent()
        {
            player = content.Load<Texture2D>("adsfasgawerhaejrak.fw");
            support = content.Load<Texture2D>("attack101");
            idleAnimation = new Animation(content.Load<Texture2D>("up"), 0.1f, true, 8);
            supportAnimation = new Animation(content.Load<Texture2D>("attack101"), 1000f, false, 6);

            int positionX = (windowWidth / 2) - (player.Width / 4);
            int positionY = (windowHeight / 2) - (player.Height / 4);
            playerPosition = new Vector2((float)positionX, (float)positionY);
            heroPosition = new Vector2((float)positionX + 150, (float)positionY - 100);
            spritePlayer.PlayAnimation(idleAnimation);
            spritePlayer1.PlayAnimation(supportAnimation);
        }

        public void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
           
          /*  if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                //playerPosition.X -= 10;
                //spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("left"), 0.1f, Action));

            }
            if (mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released)
            {
                playerPosition.X += 10;
                    spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("right"), 0.1f, Action, 8));
            }
            if (mouseState.ScrollWheelValue < oldScrollWheelValue)
            {
                playerPosition.Y += 10;
                oldScrollWheelValue = mouseState.ScrollWheelValue;
                spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("up"), 0.1f, Action, 8));
            }
            if (mouseState.ScrollWheelValue > oldScrollWheelValue)
            {
                playerPosition.Y -= 10;
                oldScrollWheelValue = mouseState.ScrollWheelValue;
                spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("down"), 0.1f, false, 8));
            }*/
        }

        public void attack() {
            spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("atk"), 0.1f, true, 2));
            spritePlayer1.PlayAnimation(new Animation(content.Load<Texture2D>("attack101"), 0.1f, true, 2));
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(player, playerPosition, Color.White);
            spritePlayer.Draw(gameTime, spriteBatch, playerPosition, SpriteEffects.None);
            spritePlayer1.Draw(gameTime, spriteBatch, heroPosition, SpriteEffects.None);
        }
    }
}
