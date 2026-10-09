using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace monogame_testing
{
    public class MojeHra : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D mojeTextura;

        public MojeHra()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D mojeTextura = new Texture2D(GraphicsDevice, 50, 50);

            Color[] pixely = new Color[50 * 50];

            for (int i = 0; i < pixely.Length; i++)
            {
                pixely[i] = Color.Black;
            }

            mojeTextura.SetData(pixely);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);

            _spriteBatch.Begin();
            _spriteBatch.Draw(mojeTextura, new Vector2(200f, 100f), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
