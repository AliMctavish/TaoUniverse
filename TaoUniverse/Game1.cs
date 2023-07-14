using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TaoUniverse.GameObjects;

namespace TaoUniverse
{

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player player; 

        public Game1()
        {
            Globals._graphics = new GraphicsDeviceManager(this);
            Globals._graphics.PreferredBackBufferWidth = 1600;
            Globals._graphics.PreferredBackBufferHeight = 800;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            IsFixedTimeStep = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Globals._content = Content;
            player = new Player(20,20);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals._spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.Update(gameTime);

            player.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            Globals._spriteBatch.Begin();

            player.Draw();

            Globals._spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}