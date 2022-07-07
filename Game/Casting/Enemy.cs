using System;

namespace DinoGame2.Game.Casting
{
    public class Enemy : Actor
    {
        int direction;
        Point velocity;
        Color color;
        string text;
        Point position;
        public List<Point> enemyHitboxList = new List<Point>();

        int fontSize = Constants.DinoAndEnemyFont_Size;        
        public Enemy()
        {
            SetupEnemy();
        }

        /// <summary>
        /// Adds the current position to the velocity to get the new position of the instance of enemy.
        /// </summary>
        public override void MoveNext()
        {
            Point position = new Point(this.GetPosition().GetX(), this.GetPosition().GetY());
            if (this.GetPosition().GetX() == 0)
            {
                this.velocity = new Point (1, 0);
            }
            if (this.GetPosition().GetX() == Constants.MAX_X)
            {
                this.velocity = new Point (-1, 0);
            }
            Point NewPosition = new Point(position.GetX() + velocity.GetX(), position.GetY() + velocity.GetY());
            this.SetPosition(NewPosition);
        }

        /// <summary>
        /// Randomly gets a starting velocity for the instance of enemy. (left or right)
        /// </summary>
        private Point EnemyChoosestartingDirection()
        {
            Random random = new Random();
            direction = random.Next(1, 3);
            //give the object a direction based on the direction variable
            //code for moving to the right
            if (direction == 1)
            {
                velocity = new Point (1,0);
            }
            //code for moving to the left
            else if (direction == 2)
            {
                velocity = new Point (-1,0);
            }
            return velocity;
        }

        /// <summary>
        /// Creates a random position for the enemy instance to spawn.
        /// </summary>
        private Point EnemyCreateStartPosition()
        {
            Random random = new Random();
            int EnemyStartingPositionY_Value = random.Next(Constants.Enemy_Top_Row, Constants.Enemy_Bottom_Row);
            int EnemyStartingPositionX_Value = random.Next(0, Constants.MAX_X);
            return new Point (EnemyStartingPositionX_Value, EnemyStartingPositionY_Value);
        }

        /// <summary>
        /// Sets the enemy's hitbox list
        /// </summary>
        public override void SetHitboxList()
        {
            this.enemyHitboxList.Clear();
            Point TopLeft = this.GetPosition();
            Point BottomLeft = new Point(this.GetPosition().GetX(), this.GetPosition().GetY() + this.fontSize);
            Point TopRight = new Point(this.GetPosition().GetX() + this.fontSize, this.GetPosition().GetY());
            Point BottomRight = new Point(this.GetPosition().GetX() + this.fontSize, this.GetPosition().GetY() + this.fontSize);
            TopLeft = TopLeft.TrimHitbox("TopLeft", 10);
            BottomLeft = BottomLeft.TrimHitbox("BottomLeft", 10);
            TopRight = TopRight.TrimHitbox("TopRight", 10);
            BottomRight = BottomRight.TrimHitbox("BottomRight", 10);
            enemyHitboxList.Add(TopLeft);
            enemyHitboxList.Add(BottomLeft);
            enemyHitboxList.Add(TopRight);
            enemyHitboxList.Add(BottomRight);
        }

        /// <summary>
        /// Gets the enemy's hitbox list
        /// </summary>
        public override List<Point> GetHitboxList()
        {
            return this.enemyHitboxList;
        }

        /// <summary>
        /// SetupEnemy sets all the values of the enemy instance.
        /// </summary>
        public void SetupEnemy()
        {   
            this.position = EnemyCreateStartPosition();
            this.velocity = EnemyChoosestartingDirection();
            this.text = "O";
            this.color = Constants.RED;
            this.SetVelocity(velocity);
            this.SetColor(color);
            this.SetText(text);
            this.SetPosition(position);

            this.SetFontSize(this.fontSize);
        }

















    }
}




