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
        private Vector2 velocity;
        private float speed = .05f;
        private float jump = .4f;
        private bool isJumping = false;
        private float currentPos = 0;
        private bool speedChanged = false;
        private float dashSpeed = 0.08f;
        private bool pressed = false;

        public struct Data
        {
            public int x;
            public int y;
            public Data(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

        }

        public Player(Data startingPosition)
        {
            position = new Vector2(startingPosition.x, startingPosition.y);
            Cube cube = new Cube();
            texture = cube.MakeCube(30, 30, Color.White);
        }
        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            position.Y += 0.1f;
            if (position.Y >= 600)
            {
                position.Y = 600;
                isJumping = false;
            }
            if (state.IsKeyDown(Keys.Right))
                velocity.X = speed * Globals.Time;
            else if (state.IsKeyDown(Keys.Left))
                velocity.X = -speed * Globals.Time;
            else
                velocity.X = 0;

            if (state.IsKeyDown(Keys.LeftControl) && !pressed)
            {
                pressed = true;
                speed = dashSpeed;
            }

            if (speed == dashSpeed)
                speedChanged = true;

            if(speedChanged)
                PlayerDash();

            if (state.IsKeyDown(Keys.Space))
            {
                velocity.Y = -jump;
                currentPos = position.Y;
                isJumping = true;
            }
            if (isJumping)
            {
                if (position.Y < currentPos + 30)
                    velocity.Y += .01f;
            }
            position += velocity * Globals.Time;
        }
        public void PlayerDash()
        {
            speed -= 0.001f;
            if (speed <= .05f)
                speedChanged = false;
        }
        public void Draw()
        {
            Globals._spriteBatch.Draw(texture, position, Color.White);
        }
    }
}

