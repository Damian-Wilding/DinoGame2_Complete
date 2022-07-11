using System.Collections.Generic;
using DinoGame2.Game.Casting;
using DinoGame2.Game.Services;
using Raylib_cs;
using DinoGame2.Game.Directing;


namespace DinoGame2.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of Draw_actors is to draw each of the actors.</para>
    /// </summary>
    public class Draw_actors : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of Draw_actors using the given KeyboardService.
        /// </summary>
        public Draw_actors(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            //gets all the actors that we will be working with in this method
            Dino dino = (Dino)cast.GetFirstActor("dino");
            Score score = (Score)cast.GetFirstActor("score");
            Goal goal = (Goal)cast.GetFirstActor("goal");
            List<Actor> enemies = cast.GetActors("enemy");

            //wipes off the screen to prepare for the new drawing
            videoService.ClearBuffer();
        
            
            //sets up all the textures to be drawn
            string dinoImage = dino.ActorImage;
            Texture2D player = Raylib.LoadTexture(dinoImage);
            Enemy enemy = (Enemy)cast.GetFirstActor("enemy");
            string enemyImageLeft = enemy.ActorImageLeft;
            string enemyImageRight = enemy.ActorImage;
            Texture2D badGuyRight = Raylib.LoadTexture(enemyImageRight);
            Texture2D badGuyLeft = Raylib.LoadTexture(enemyImageLeft);
            string grassPath = "images/grass2.png";
            Texture2D grass = Raylib.LoadTexture(grassPath);

            //draws grass (you should touch some dude)
            Raylib.DrawTexture(grass, 0, 0, Raylib_cs.Color.WHITE);
            Raylib.DrawTexture(grass, 0, 320, Raylib_cs.Color.WHITE);
            Raylib.DrawTexture(grass, 704, 0, Raylib_cs.Color.WHITE);
            Raylib.DrawTexture(grass, 704, 320, Raylib_cs.Color.WHITE);
            
            //draws the goal (the brick blocks)
            string goalImage = goal.ActorImage;
            Texture2D GoalTexture = Raylib.LoadTexture(goalImage);
            Raylib.DrawTexture(GoalTexture, 0, goal.GoalsHitBoxY - 128, Raylib_cs.Color.WHITE);

            //draw the score and the black background behind it
            Image ScoreBackgroundImage = Raylib.GenImageColor(30, 20, Raylib_cs.Color.BLACK);
            Texture2D ScoreBackground = Raylib.LoadTextureFromImage(ScoreBackgroundImage);
            videoService.DrawActor(score);
            
            //draws the dino player
            Raylib.DrawTexture(player, dino.GetPosition().GetX(), dino.GetPosition().GetY(), Raylib_cs.Color.WHITE);

            //draws the evil dinos based on the direction they're headed
            foreach (Enemy enemy2 in enemies)
            {
                if (enemy2.GetVelocity().Equals(new Point(1,0)))
                {
                    Raylib.DrawTexture(badGuyRight, enemy2.GetPosition().GetX(), enemy2.GetPosition().GetY(), Raylib_cs.Color.WHITE);
                }
                else
                {
                    Raylib.DrawTexture(badGuyLeft, enemy2.GetPosition().GetX(), enemy2.GetPosition().GetY(), Raylib_cs.Color.WHITE);    
                }
                
            }


            videoService.FlushBuffer();
        }
    }
}