using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoUniverse
{
    public static class Globals
    {
        public static float Time { get; set; }
        public static SpriteBatch _spriteBatch;
        public static ContentManager _content;
        public static GraphicsDeviceManager _graphics;
        public static GameDebugger _gameDebugger;   

        public static SpriteFont Font()
        {
            return _gameDebugger.GetFont();
        }

        public static void Update(GameTime gt)
        {
            Time = gt.ElapsedGameTime.Milliseconds;
        }


    }
}
