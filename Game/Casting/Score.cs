using System;


namespace DinoGame2.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        private int points = 0;
        private int fontSize = Constants.FONT_SIZE;
        private Color color = Constants.WHITE;
        public new string text = "0";
        private Point position = Constants.scorePosition;

        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public Score()
        {
            //AddPoints(0);     idk what this even is or if its needed
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this.points += points;
            SetText($"Score: {this.points}");
        }

        /// <summary>
        /// Returns the scores' text content
        /// </summary>
        public override string GetText()
        {
            return this.text;
        }

        /// <summary>
        /// Returns the scores' color
        /// </summary>
        public override Color GetColor()
        {
            return this.color;
        }

        /// <summary>
        /// Returns the scores' position
        /// </summary>
        public override Point GetPosition()
        {
            return this.position;
        }

        /// <summary>
        /// Returns the scores' fontsize
        /// </summary>
        public override int GetFontSize()
        {
            return this.fontSize;
        }
        public override void SetText(string newscore)
        {
            this.text = newscore;
        }
    }
}