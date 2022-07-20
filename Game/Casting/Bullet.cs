using System;
using System.Collections.Generic;
using Raylib_cs;

namespace DinoGame2.Game.Casting
{
    class Bullet : Actor
    {
        private Point velocity = new Point (0, -5);
        public Point position = new Point(0, 0);
        private string BulletTexturePath = "images/fireball.png";
        public List<Point> bulletHitboxList = new List<Point>();
        public Texture2D BulletTexture;
        public string text = "|";
        private int fontSize = 20;
        Cast cast;

        public Bullet(Cast cast)
        {

            Dino dino = (Dino)cast.GetFirstActor("dino");
            int BulletStartX = dino.GetPosition().GetX() + Constants.DinoAndEnemyFont_Size;
            int BulletStartY = dino.GetPosition().GetY();
            this.position = new Point (BulletStartX, BulletStartY);
            BulletTexture = Raylib.LoadTexture(this.BulletTexturePath);
            this.SetPosition(position);
            this.cast = cast;
        }

        public void SetHitboxList()
        {
            this.bulletHitboxList.Clear();
            Point TopLeft = this.GetPosition();
            Point BottomLeft = new Point(this.GetPosition().GetX(), this.GetPosition().GetY() + this.fontSize);
            Point TopRight = new Point(this.GetPosition().GetX() + this.fontSize / 2, this.GetPosition().GetY());
            Point BottomRight = new Point(this.GetPosition().GetX() + this.fontSize / 2, this.GetPosition().GetY() + this.fontSize);
            //TopLeft = TopLeft.TrimHitbox("TopLeft", 10);
            //BottomLeft = BottomLeft.TrimHitbox("BottomLeft", 10);
            //TopRight = TopRight.TrimHitbox("TopRight", 10);
            //BottomRight = BottomRight.TrimHitbox("BottomRight", 10);
            bulletHitboxList.Add(TopLeft);
            bulletHitboxList.Add(BottomLeft);
            bulletHitboxList.Add(TopRight);
            bulletHitboxList.Add(BottomRight);
        }

        public override List<Point> GetHitboxList()
        {
            return this.bulletHitboxList;
        }

        public override Point GetVelocity()
        {
            return this.velocity;
        }

        public override void MoveNext()
        {
            int x = (position.GetX() + velocity.GetX());
            int y = (position.GetY() + velocity.GetY());
            //System.Console.WriteLine(x);
            //System.Console.WriteLine(y);
            this.position = new Point(x, y);
            RemoveStrayBullets(cast);
        }

        public void RemoveStrayBullets(Cast cast)
        {
            List<Actor> bulletList = cast.GetActors("bullet");
            foreach (Bullet bulletBoi in bulletList)
            {
                if (bulletBoi.GetPosition().GetY() <= 0)
                {
                    cast.RemoveActor("bullet", bulletBoi);
                }
            }
        }

        public override Point GetPosition()
        {
            return position;
        }
    }
        
}