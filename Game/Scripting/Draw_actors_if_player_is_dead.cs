using Raylib_cs;
using System;
using DinoGame2.Game.Services;
using DinoGame2.Game.Casting;

namespace DinoGame2.Game.Scripting
{
    public class Draw_actors_if_player_is_dead : Action
    {
        public VideoService videoService;
        public Texture2D explosion = new Texture2D();
        public string explosion_texture_path = "images/explosion_sprite_sheet_no_green.png";
        float timer = 0.0f;
        int frame = 0;
        
        public Draw_actors_if_player_is_dead(VideoService videoservice)
        {
            this.videoService = videoservice;
            this.explosion = Raylib.LoadTexture(explosion_texture_path);
        }
        
        public void Execute(Cast cast, Script script)
        {
            //load all the actors that will be drawn after the player dies
            Dino dino = (Dino)cast.GetFirstActor("dino");
            Score score = (Score)cast.GetFirstActor("score");
            Goal goal = (Goal)cast.GetFirstActor("goal");
            List<Actor> enemies = cast.GetActors("enemy");
            Background background = (Background)cast.GetFirstActor("background");
            Enemy enemy = (Enemy)cast.GetFirstActor("enemy");
            Actor gameOverMessage = cast.GetFirstActor("messages");

            //wipes off the screen to prepare for the new drawing
            videoService.ClearBuffer();

            //draws grass (you should touch some dude)
            Raylib.DrawTexture(background.Texture, 0, 0, Raylib_cs.Color.WHITE);
            Raylib.DrawTexture(background.Texture, 0, 320, Raylib_cs.Color.WHITE);
            Raylib.DrawTexture(background.Texture, 704, 0, Raylib_cs.Color.WHITE);
            Raylib.DrawTexture(background.Texture, 704, 320, Raylib_cs.Color.WHITE);

            //draws goal
            Raylib.DrawTexture(goal.Texture, 0, goal.GoalsHitBoxY - 128, Raylib_cs.Color.WHITE);

            //draws the evil dinos based on the direction they're headed
            foreach (Enemy enemy2 in enemies)
            {
                if (enemy2.GetVelocity().Equals(new Point(1,0)))
                {
                    Raylib.DrawTexture(enemy2.Texture, enemy2.GetPosition().GetX(), enemy2.GetPosition().GetY(), Raylib_cs.Color.WHITE);
                }
                else
                {
                    Raylib.DrawTexture(enemy2.Texture, enemy2.GetPosition().GetX(), enemy2.GetPosition().GetY(), Raylib_cs.Color.WHITE);    
                }
                
            }

            timer += Raylib.GetFrameTime();
            if (timer >= 0.1f)
            {
                timer += 0.0f;
                frame += 1;
            }

            int explosionXValue = frame % 15;
            Raylib.DrawTextureRec(explosion, new Rectangle(frame * 45, 0, 45, 45), new System.Numerics.Vector2(dino.GetPosition().GetX(), dino.GetPosition().GetY()), Raylib_cs.Color.WHITE);
            videoService.DrawActor(gameOverMessage);
            
            //finishes the drawing so that it can be displayed on screen
            videoService.FlushBuffer();
        }


    }
}