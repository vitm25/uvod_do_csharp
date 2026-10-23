using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace monogame_testing
{
    internal class Klavesnice
    {
        KeyboardState ted;
        KeyboardState minule;

        public void Aktualizuj()
        {
            minule = ted;
            ted = Keyboard.GetState();
        }

        public bool JeZmacknuta(Keys klavesa)
        {
            return ted.IsKeyDown(klavesa);
        }

        public bool PraveZmacknuta(Keys klavesa)
        {
            return ted.IsKeyDown(klavesa) && minule.IsKeyUp(klavesa);
        }

        public bool ChceUkoncit()
        {
            return ted.IsKeyDown(Keys.Escape);
        }

        public Vector2 Smer()
        {
            Vector2 smer = Vector2.Zero;

            if (ted.IsKeyDown(Keys.Right) || ted.IsKeyDown(Keys.D))
                smer.X += 1;
            if (ted.IsKeyDown(Keys.Left) || ted.IsKeyDown(Keys.A))
                smer.X -= 1;
            if (ted.IsKeyDown(Keys.Down) || ted.IsKeyDown(Keys.S))
                smer.Y += 1;
            if (ted.IsKeyDown(Keys.Up) || ted.IsKeyDown(Keys.W))
                smer.Y -= 1;

            if (smer != Vector2.Zero)
                smer.Normalize();

            return smer;
        }
    }
}
