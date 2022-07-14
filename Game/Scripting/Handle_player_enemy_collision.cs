using System;
using System.Collections.Generic;
using System.Data;
using DinoGame2.Game.Casting;
using DinoGame2.Game.Services;
using Raylib_cs;

namespace DinoGame2.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the dino 
    /// collides with the enemy, or the dino collides with the goal, or the game is over.
    /// </para>
    /// </summary>
    public class Handle_player_enemy_collision : Action
    {
        public bool isGameOver = false;
        public bool isPlayerExploding;
        List<List<Point>> allEnemiesHitboxList = new List<List<Point>>();
        /// <summary>
        /// Constructs a new instance of Handle_collision.
        /// </summary>
        public Handle_player_enemy_collision()
        {
            isPlayerExploding = false;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleEnemyCollisions(cast);
                HandleGoalCollisions(cast);
                HandleGameOver(cast);
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
                System.Console.WriteLine(ScoreAsINT);

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

                //cast.RemoveActor("dino", dino);
                //cast.AddActor("dino", new Dino());
                // moves the dino back to its spawn point
                dino.SetPosition(Constants.DinoSpawn);
                
            }
        }

        //code for if the player touches an enemy
        private void HandleEnemyCollisions(Cast cast)
        {
            List<Actor> enemies = cast.GetActors("enemy");
            Dino dino = (Dino)cast.GetFirstActor("dino");
            Score score = (Score)cast.GetFirstActor("score");
            Goal goal = (Goal)cast.GetFirstActor("goal");
            List<Actor> dinos = cast.GetActors("dino");
            string yeah = score.GetText();
            

            allEnemiesHitboxList.Clear();
            foreach (Enemy enemy in enemies)
            {
                enemy.SetHitboxList();
                allEnemiesHitboxList.Add(enemy.GetHitboxList());
            }

            dino.SetHitboxList();
            foreach (Point DinoPoint in dino.dinoHitboxList)
            {
                foreach (Enemy enemy in enemies)
                {
                    enemy.SetHitboxList();
                    Point enemyPosition_TopLeft = enemy.enemyHitboxList[0];
                    Point enemyPosition_BottomRight = enemy.enemyHitboxList[3];
                    int enemyPosition_TopLeftX = enemyPosition_TopLeft.GetX();
                    int enemyPosition_TopLeftY = enemyPosition_TopLeft.GetY();
                    int enemyPosition_BottomRightX = enemyPosition_BottomRight.GetX();
                    int enemyPosition_BottomRightY = enemyPosition_BottomRight.GetY();

                    
                    int dinoX = DinoPoint.GetX();
                    int dinoY = DinoPoint.GetY();
                    
                    // Checks to see if any of the corners of the dino hitbox are inside the enemy.
                    if ((Enumerable.Range(enemyPosition_TopLeftX, enemy.GetFontSize() + 1).Contains(dinoX)) && (Enumerable.Range(enemyPosition_TopLeftY, enemy.GetFontSize() + 1).Contains(dinoY)))
                    {
                        isGameOver = true;
                        break;
                    }
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            Actor score = cast.GetFirstActor("score");
            int BannerAsINT = int.Parse(score.GetText());

            if (isGameOver == true)
            {
                //make a game over screen and display the final score
                Actor GameOverMessage = new Actor();
                GameOverMessage.SetText($"Game Over \n Score: {BannerAsINT}");
                GameOverMessage.SetPosition(Constants.GameOverMessagePosition);
                GameOverMessage.SetColor(Constants.WHITE);
                GameOverMessage.SetFontSize(Constants.DinoAndEnemyFont_Size);
                cast.AddActor("messages", GameOverMessage);
                
                
                
            
            
                //Raylib.ClearBackground(Raylib_cs.Color.BLACK);
                //Raylib.DrawText(GameOverMessage, Constants.MAX_X / 2, Constants.MAX_Y / 2, Constants.FONT_SIZE, Raylib_cs.Color.WHITE);

            

                //for now we'll just delete the dino if it touches a bad guy. later I'd like to make a class to make it so you can start a new game.

                // not sure if this will work, but it is just deleting everything in the cast resembles a dino
                List<Actor> dinos = cast.GetActors("dino");
                foreach (Actor player in dinos)
                {
                    cast.RemoveActor("dino", player);
                }

            }
        }

    
    }
}