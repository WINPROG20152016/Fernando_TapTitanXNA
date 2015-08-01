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
        ContentManager content;
        MouseState mouseState;
        MouseState oldMouseState;
        Level level;
        Boolean Action = true;
        Animation idleAnimation;
        AnimationPlayer spritePlayer;
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

            idleAnimation = new Animation(content.Load<Texture2D>("up"), 0.1f, true);

            int positionX = (windowWidth / 2) - (player.Width / 4);
            int positionY = (windowHeight / 2) - (player.Height / 4);
            playerPosition = new Vector2((float)positionX, (float)positionY);

            spritePlayer.PlayAnimation(idleAnimation);
        }

        public void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
           
            if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                playerPosition.X -= 10;
                spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("left"), 0.1f, Action));

            }
            if (mouseState.RightButton == ButtonState.Pressed && oldMouseState.RightButton == ButtonState.Released)
            {
                playerPosition.X += 10;
                    spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("right"), 0.1f, Action));
            }
            if (mouseState.ScrollWheelValue < oldScrollWheelValue)
            {
                playerPosition.Y += 10;
                oldScrollWheelValue = mouseState.ScrollWheelValue;
                spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("up"), 0.1f, Action));
            }
            if (mouseState.ScrollWheelValue > oldScrollWheelValue)
            {
                playerPosition.Y -= 10;
                oldScrollWheelValue = mouseState.ScrollWheelValue;
                spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("down"), 0.1f, false));
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(player, playerPosition, Color.White);
            spritePlayer.Draw(gameTime, spriteBatch, playerPosition, SpriteEffects.None);
        }
    }
}
