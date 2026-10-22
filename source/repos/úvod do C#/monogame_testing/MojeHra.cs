using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;

namespace monogame_testing
{
    public class MojeHra : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D mojeTextura;

        float x, y;
        float rychlost = 5;

        List<Vector2> trail = new List<Vector2>();

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

            x = (GraphicsDevice.Viewport.Width - 50) / 2f;
            y = (GraphicsDevice.Viewport.Height - 50) / 2f;

            mojeTextura = new Texture2D(GraphicsDevice, 50, 50); //čtvereček

            Color[] pixely = new Color[50 * 50];

            for (int i = 0; i < pixely.Length; i++)
            {
                pixely[i] = Color.Black;
            }

            mojeTextura.SetData(pixely);

            for (int g = 0; g < pixely.Length; g++)
            {
                pixely[g] = Color.Black;
            }

            mojeTextura.SetData(pixely);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Vector2 smer = new Vector2(0, 0);

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                smer += new Vector2(1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                smer += new Vector2(-1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                smer += new Vector2(0, 1);
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                smer += new Vector2(0, -1);

            if (Keyboard.GetState().IsKeyDown(Keys.D))
                smer += new Vector2(1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                smer += new Vector2(-1, 0);
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                smer += new Vector2(0, 1);
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                smer += new Vector2(0, -1);

            if (smer != Vector2.Zero)
                smer.Normalize();

            x += (rychlost * smer).X;
            y += (rychlost * smer).Y;

            trail.Add(new Vector2(x, y));
            if (trail.Count > 15)
                trail.RemoveAt(0);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            for (int g = 0; g < trail.Count; g++)
            {
                float pruhlednost = (float)g / trail.Count;
                _spriteBatch.Draw(mojeTextura, trail[g], Color.White * pruhlednost);
            }
            _spriteBatch.Draw(mojeTextura, new Vector2(x, y), Color.Red);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
