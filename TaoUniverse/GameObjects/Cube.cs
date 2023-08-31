using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoUniverse.GameObjects
{
    public class Cube
    {
        public Texture2D _texture;
        private Color[] _textureData;

        public Texture2D MakeCube(int width , int height , Color color)
        {
            _textureData = new Color[width * height];
            _texture = new Texture2D(Globals._graphics.GraphicsDevice, width, height);

            for (int i = 0; i < _textureData.Length; i++)
            {
                _textureData[i] = color;
            }
            _texture.SetData(_textureData);

            return _texture;
        }

    }
}
