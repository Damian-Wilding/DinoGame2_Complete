using System.Collections.Generic;
using DinoGame2.Game.Casting;
using DinoGame2.Game.Scripting;
using DinoGame2.Game.Services;
using Raylib_cs;

namespace DinoGame2.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>

    public class Director
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="videoService">The given VideoService.</param>
        public Director(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast and script.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        /// <param name="script">The given script.</param>
        public void StartGame(Cast cast, Script script)
        {
            
            videoService.OpenWindow();

            


            
            while (videoService.IsWindowOpen())
            {
                //Raylib.BeginDrawing();
                //Raylib_cs raylib = new Raylib_cs();
                //VideoService.Image DinoImage = LoadImage("DinoGame2_Complete/images/CompleteDino.png");
                //Texture2D player = Raylib.LoadTexture("DinoGame2_Complete/images/CompleteDino.png");
                //Raylib.DrawTexture(player, Constants.DinoSpawn.GetX(), Constants.DinoSpawn.GetY(), Raylib_cs.Color.WHITE);
                // UnloadTexture(player);
                ExecuteActions("input", cast, script);
                ExecuteActions("update", cast, script);
                ExecuteActions("output", cast, script);
            }
            videoService.CloseWindow();
            //Raylib.UnloadTexture(player);
            //Raylib.UnloadTexture(badGuy);
            //Raylib.UnloadTexture(GoalTexture);
        }
        /// <summary>
        /// Calls execute for each action in the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actions.</param>
        private void ExecuteActions(string group, Cast cast, Script script)
        {
            List<DinoGame2.Game.Scripting.Action> actions = script.GetActions(group);
            foreach(DinoGame2.Game.Scripting.Action action in actions)
            {
                action.Execute(cast, script);
            }
        }
    }
}