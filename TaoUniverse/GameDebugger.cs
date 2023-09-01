
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Security.Cryptography.X509Certificates;

namespace TaoUniverse
{
    public class GameDebugger
    {
        private SpriteFont Font;
        private Vector2 currentLocation;
        private static int locationCounter;

        private void InIt()
        {
            Font = Globals._content.Load<SpriteFont>("TextDebugger");
        }
        public SpriteFont GetFont()
        {
            return Font;
        }
        public GameDebugger()
        {
            this.InIt();
        }
        public Vector2 GetLocation()
        {
            currentLocation = new Vector2(10, 10 + locationCounter);

            locationCounter+= 20;  

            return currentLocation;
        }


        public void Draw(string message)
        {
            Globals._spriteBatch.DrawString(Font, message, currentLocation, Color.Wheat);
        }
    }
}