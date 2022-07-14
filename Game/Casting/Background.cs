using Raylib_cs;

namespace DinoGame2.Game.Casting
{
    class Background : Actor
    {
        public Texture2D Texture = new Texture2D();
        public string TexturePath = "images/grass2.png";

        public Background()
        {
            Texture = Raylib.LoadTexture(this.TexturePath);
        }
    }
}