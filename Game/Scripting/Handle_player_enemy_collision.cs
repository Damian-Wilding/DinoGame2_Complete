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
                HandleGameOver(cast);
            }
            
            
        }

        //code that checks if player touches an enemy and for what to do if that happens
        private void HandleEnemyCollisions(Cast cast)
        {
            List<Actor> enemies = cast.GetActors("enemy");
            Dino dino = (Dino)cast.GetFirstActor("dino");
            Score score = (Score)cast.GetFirstActor("score");
            Goal goal = (Goal)cast.GetFirstActor("goal");
            List<Actor> dinos = cast.GetActors("dino");
            string yeah = score.GetText();
            
            //all this code is checking if there is a player to enemy collision
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
                        //code for what to do if you hit an enemy
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
                GameOverMessage.SetText($"Game Over \n Score: {BannerAsINT} \n Press ENTER to close the game");
                GameOverMessage.SetPosition(Constants.GameOverMessagePosition);
                GameOverMessage.SetColor(Constants.BLACK);
                GameOverMessage.SetFontSize(Constants.DinoAndEnemyFont_Size);
                cast.AddActor("messages", GameOverMessage);
                
            }
        }

    
    }
}