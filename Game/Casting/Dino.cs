using System;
using System.Collections.Generic;
using System.Linq;
using Raylib_cs;

namespace DinoGame2.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Dino is to move itself.</para>
    /// </summary>
    public class Dino : Actor
    {
        Color color = Constants.BLUE;
        private Point position = Constants.DinoSpawn;
        public string text = " ";
        Point velocity = new Point(0, 0);
        int fontSize = Constants.DinoAndEnemyFont_Size;
        public List<Point> dinoHitboxList = new List<Point>();
        public string ActorImageText = "images/dinoComplete45.png";
        public string ActorImageLeftText = "images/dinoComplete45Left.png";
        public string texturePath = "images/dinoComplete45.png";
        public Texture2D Texture = new Texture2D();
        public Texture2D TextureR = new Texture2D();
        public Texture2D TextureL = new Texture2D();

        /// <summary>
        /// Constructs a new instance of a Dino.
        /// </summary>
        public Dino()
        {
            PrepareBody();
            this.TextureR = Raylib.LoadTexture(this.ActorImageText);
            this.TextureL = Raylib.LoadTexture(this.ActorImageLeftText);
            this.Texture = TextureR;
        }

        /// <summary>
        /// Gets the dino's color
        /// </summary>
        /// <returns>the color of the dino</returns>
        public override Color GetColor()
        {
            return this.color;
        }

        /// <summary>
        /// Gets the dino's hitbox list
        /// </summary>
        public override List<Point> GetHitboxList()
        {
            return this.dinoHitboxList;
        }

        /// <summary>
        /// Gets the dino's position
        /// </summary>
        /// <returns>The dino's position as a Point</returns>
        public override Point GetPosition()
        {
            return this.position;
        }

        /// <summary>
        /// Gets the dino's text
        /// </summary>
        /// <returns>The dino's text as a string value</returns>
        public override string GetText()
        {
            return this.text;
        }

        /// <summary>
        /// Gets the dino's 
        /// </summary>
        /// <returns>The dino's </returns>
        public override int GetFontSize()
        {
            return this.fontSize;
        }

        /// <summary>
        /// Gets the dino's velocity
        /// </summary>
        /// <returns>The dino's velocity as a Point</returns>
        public override Point GetVelocity()
        {
            return this.velocity;
        }

        /// <summary>
        /// Sets the dino's hitbox list
        /// </summary>
        public override void SetHitboxList()
        {
            this.dinoHitboxList.Clear();
            Point TopLeft = this.GetPosition();
            Point BottomLeft = new Point(this.GetPosition().GetX(), this.GetPosition().GetY() + this.fontSize);
            Point TopRight = new Point(this.GetPosition().GetX() + this.fontSize, this.GetPosition().GetY());
            Point BottomRight = new Point(this.GetPosition().GetX() + this.fontSize, this.GetPosition().GetY() + this.fontSize);
            TopLeft = TopLeft.TrimHitbox("TopLeft", 10);
            BottomLeft = BottomLeft.TrimHitbox("BottomLeft", 10);
            TopRight = TopRight.TrimHitbox("TopRight", 10);
            BottomRight = BottomRight.TrimHitbox("BottomRight", 10);
            dinoHitboxList.Add(TopLeft);
            dinoHitboxList.Add(BottomLeft);
            dinoHitboxList.Add(TopRight);
            dinoHitboxList.Add(BottomRight);
        }

        /// <summary>
        /// Sets the velocity of the dino
        /// <summary>
        public override void SetVelocity(Point newVelocity)
        {
            this.velocity = newVelocity;
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            int x = (position.GetX() + velocity.GetX());
            int y = (position.GetY() + velocity.GetY());
            this.position = new Point(x, y);
            if (velocity.GetX() < 0)
            {
                this.Texture = this.TextureL;
            }
            if (velocity.GetX() > 0)
            {
                this.Texture = this.TextureR;
            }
        }

        /// <summary>
        /// sets the dino's position
        /// </summary>
        public override void SetPosition(Point point)
        {
            this.position = point;
        }

        /// <summary>
        /// Prepares the Dino by setting all its attributes
        /// </summary>
        private void PrepareBody()
        {
            Point position = this.position;
            Point velocity = this.velocity;
            string text = this.text;
            Color color = this.color;
            this.SetPosition(position);
            this.SetVelocity(velocity);
            this.SetText(text);
            this.SetColor(color);
        }

        ///<summary>
        /// gets and returns the texture of the dino
        ///</summary>
        public Texture2D GetTexture()
        {
            return this.Texture;
        }

        ///<summary>
        /// sets the dinos texture
        ///</summary>
        public void SetTexture(string path)
        {
            this.Texture = Raylib.LoadTexture(path);
        }
    }
}
