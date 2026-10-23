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

        Klavesnice klavesnice = new Klavesnice();

        public MojeHra()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
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
                pixely[i] = Color.White;
            }

            mojeTextura.SetData(pixely);
        }

        protected override void Update(GameTime gameTime)
        {
            klavesnice.Aktualizuj();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || klavesnice.ChceUkoncit())
                Exit();

            Vector2 smer = klavesnice.Smer();

            x += (rychlost * smer).X;
            y += (rychlost * smer).Y;
            
            if (x < 0) 
                x = 0;
            if (y < 0) 
                y = 0;
            if (x > GraphicsDevice.Viewport.Width - 50)
                x = GraphicsDevice.Viewport.Width - 50;
            if (y >  GraphicsDevice.Viewport.Height - 50)
                y = GraphicsDevice.Viewport.Height - 50;


            trail.Add(new Vector2(x, y));
            if (trail.Count > 15)
                trail.RemoveAt(0);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            for (int g = 0; g < trail.Count; g++)
            {
                float pruhlednost = (float)g / trail.Count;
                _spriteBatch.Draw(mojeTextura, trail[g], Color.Black * pruhlednost);
            }
            _spriteBatch.Draw(mojeTextura, new Vector2(x, y), Color.DarkRed);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
