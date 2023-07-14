using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TaoUniverse.GameObjects
{
    public class Player
    {
        public Vector2 position;
        public Texture2D texture;
        private Color[] textureData;
        private Vector2 velocity;
        private float speed = .5f;
        private float jump = .4f;
        private bool isJumping = false;
        private bool isGrounded = false;
        private float currentPos = 0;


        public Player(int x, int y)
        {
            position = new Vector2(x, y);
            textureData = new Color[25 * 2];
            texture = new Texture2D(Globals._graphics.GraphicsDevice, 5,10);

            for (int i = 0; i < textureData.Length; i++)
            {
                textureData[i] = Color.Red;
            }
            texture.SetData(textureData);
        }
        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            position.Y+= 0.1f ;
            if(position.Y >= 600)
            {
                position.Y = 600;
                isJumping = false;
            }
            if (state.IsKeyDown(Keys.Right))
                velocity.X =  speed;
            else if(state.IsKeyDown(Keys.Left))
                velocity.X = -speed;    
            else
                velocity.X = 0; 

            if (state.IsKeyDown(Keys.Space))
            {
                velocity.Y = -jump;
                currentPos = position.Y;
                isJumping = true;
            }
            if(isJumping)
            {
                if(position.Y < currentPos + 30) 
                    velocity.Y+= .01f;
            }
            position += velocity * Globals.Time;
        }

        public void Draw()
        {
            Globals._spriteBatch.Draw(texture, position, Color.White);
        }
        
    }
}
