using System.Collections.Generic;
using DinoGame2.Game.Casting;
using DinoGame2.Game.Services;
using Raylib_cs;
using DinoGame2.Game.Directing;
using System.Numerics;
using DinoGame2.Game;


namespace DinoGame2.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of Draw_actors is to draw each of the actors.</para>
    /// </summary>
    public class Draw_actors : Action
    {
        private VideoService videoService;
        //DinoGame2.Game.Services.Timer frameCount;
        public Texture2D explosion;
        //private bool isGameOver;
        //public MyTimer frameCount;

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
            Background background = (Background)cast.GetFirstActor("background");
            Enemy enemy = (Enemy)cast.GetFirstActor("enemy");

            //wipes off the screen to prepare for the new drawing
            videoService.ClearBuffer();
            
            //sets up all the textures to be drawn
            string enemyImageLeft = enemy.ActorImageLeft;
            string enemyImageRight = enemy.ActorImage;
            //Texture2D badGuyRight = Raylib.LoadTexture(enemyImageRight);
            //Texture2D badGuyLeft = Raylib.LoadTexture(enemyImageLeft);
            

            //draws grass (you should touch some dude)
            Raylib.DrawTexture(background.Texture, 0, 0, Raylib_cs.Color.WHITE);
            Raylib.DrawTexture(background.Texture, 0, 320, Raylib_cs.Color.WHITE);
            Raylib.DrawTexture(background.Texture, 704, 0, Raylib_cs.Color.WHITE);
            Raylib.DrawTexture(background.Texture, 704, 320, Raylib_cs.Color.WHITE);
            
            //draws goal
            Raylib.DrawTexture(goal.Texture, 0, goal.GoalsHitBoxY - 128, Raylib_cs.Color.WHITE);

            //draw the score and the black background behind it
            //Image ScoreBackgroundImage = Raylib.GenImageColor(30, 20, Raylib_cs.Color.BLACK);
            
            //Texture2D ScoreBackground = Raylib.LoadTextureFromImage(ScoreBackgroundImage);
            
            Raylib.DrawTexture(score.scoreBackgroundTexture, 0, 0, Raylib_cs.Color.BLACK);
            videoService.DrawActor(score);
            
            //draws the dino player
            Raylib.DrawTexture(dino.Texture, dino.GetPosition().GetX(), dino.GetPosition().GetY(), Raylib_cs.Color.WHITE);

            //draws the evil dinos based on the direction they're headed
            foreach (Enemy enemy2 in enemies)
            {
                if (enemy2.GetVelocity().Equals(new Point(1,0)))
                {
                    Raylib.DrawTexture(enemy.Texture, enemy2.GetPosition().GetX(), enemy2.GetPosition().GetY(), Raylib_cs.Color.WHITE);
                }
                else
                {
                    Raylib.DrawTexture(enemy.Texture, enemy2.GetPosition().GetX(), enemy2.GetPosition().GetY(), Raylib_cs.Color.WHITE);    
                }
                
            }
            
            //test draw explosion

            //this.explosion = Raylib.LoadTexture("images/explosion_sprite_sheet_no_green.png");
            Raylib.DrawTextureRec(explosion, new Rectangle(450, 0, 45, 45), new Vector2(300, 300), Raylib_cs.Color.WHITE);
            
            videoService.FlushBuffer();
            //Raylib.UnloadImage(ScoreBackgroundImage);
            //Raylib.UnloadTexture(ScoreBackground);
            //frameCount.TimerUpdate();
        }
    }
}