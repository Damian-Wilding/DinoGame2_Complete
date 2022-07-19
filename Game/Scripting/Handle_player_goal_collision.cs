using System;
using System.Collections.Generic;
using System.Data;
using DinoGame2.Game.Casting;
using DinoGame2.Game.Services;
using Raylib_cs;

namespace DinoGame2.Game.Scripting
{
    /// <summary>
    /// <para></para>
    /// <para>
    /// 
    /// </para>
    /// </summary>
    public class Handle_player_goal_collision : Action
    {
        public bool isGameOver = false;
        public bool isPlayerExploding;
        List<List<Point>> allEnemiesHitboxList = new List<List<Point>>();
        /// <summary>
        /// Constructs a new instance of Handle_collision.
        /// </summary>
        public Handle_player_goal_collision()
        {
            isPlayerExploding = false;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleGoalCollisions(cast);
            }
            
            
        }

        /// <summary>
        /// Updates the score and moves the player if the Dino touches the goal.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleGoalCollisions(Cast cast)
        {
            List<Actor> enemies = cast.GetActors("enemy");
            Dino dino = (Dino)cast.GetFirstActor("dino");
            Score score = (Score)cast.GetFirstActor("score");
            Goal goal = (Goal)cast.GetFirstActor("goal");
            List<Actor> bullets = cast.GetActors("bullet");
            
            
            // checks to see if the dino is touching the goal
            if (dino.GetPosition().GetY() <= goal.GoalsHitBoxY)
            {
                
                // removes all enemies from the screen
                foreach (Enemy enemy in enemies)
                {
                    cast.RemoveActor("enemy", enemy);
                }

                // Turn the text of score into an int
                string scoreString = score.GetText(); 
                int ScoreAsINT = Int32.Parse(scoreString);
                //System.Console.WriteLine(ScoreAsINT);

                // add the goal point(s) to that int
                ScoreAsINT += goal.points;

                // ads in as many enemies as there are points in the game
                for (int i = 1; i <= ScoreAsINT + 1; i++)
                {
                    cast.AddActor("enemy", new Enemy());
                }

                // turn it back into a string
                string NewScore = ScoreAsINT.ToString();

                // set that new score as the score to be displayed
                score.SetText(NewScore);

                // moves the dino back to its spawn point
                dino.SetPosition(Constants.DinoSpawn);

                //remove all left over bullets
                foreach (Bullet bulletBoi in bullets)
                {
                    cast.RemoveActor("bullet", bulletBoi);
                }
                
            }
        }

    }
}