using System.Collections.Generic;
using DinoGame2.Game.Casting;
using DinoGame2.Game.Services;
using Raylib_cs;


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
            
            Dino dino = (Dino)cast.GetFirstActor("dino");
            Score score = (Score)cast.GetFirstActor("score");
            Goal goal = (Goal)cast.GetFirstActor("goal");
            List<Actor> enemies = cast.GetActors("enemy");

            videoService.ClearBuffer();
            videoService.DrawActor(score);
            videoService.DrawActor(dino);
            videoService.DrawActor(goal);
            videoService.DrawActors(enemies);
            videoService.FlushBuffer();

            Raylib.BeginDrawing();
            //VideoService.Image DinoImage = LoadImage("DinoGame2_Complete/images/CompleteDino.png");
            Image player = Raylib.LoadImage("DinoGame2_Complete/images/CompleteDino.png");
            //Raylib.ImageResize(player, dino.GetFontSize(), dino.GetFontSize());
            //Raylib.ImageDraw(player, (Rectangle){0, 0 (float)player.width, (float)player.height}, (Rectangle){ 30, 40, player.width*1.5f, player.height*1.5f }, Raylib_cs.Color.WHITE);
            //Raylib.UnloadTexture(player);
            Raylib.EndDrawing();
            
        }
    }
}