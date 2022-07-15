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
        //public Image DinoImage;
        //public Image EnemyImage;
        //public Image GoalImage;
        private VideoService videoService;
        //public MyTimer timer;
        public Handle_player_enemy_collision handle_Player_Enemy_Collision;
        //Texture2D backgroundImage = new Texture2D();

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="videoService">The given VideoService.</param>
        public Director(VideoService videoService, Handle_player_enemy_collision handle_player_enemy_collision)
        {
            this.videoService = videoService;
            this.handle_Player_Enemy_Collision = handle_player_enemy_collision;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast and script.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        /// <param name="script">The given script.</param>
        public void StartGame(Cast cast, Script script)
        {
            //Raylib.InitAudioDevice();
            

            SoundService soundService = new SoundService();

            //returns true if the audio device is configured properly
            Console.WriteLine(Raylib.IsAudioDeviceReady());

            
            soundService.PlaySound(soundService.GetSound());
            

            //load all the textures that will be used in the game.

            Background background = (Background)cast.GetFirstActor("background");
            Dino dino = (Dino)cast.GetFirstActor("dino");
            Enemy enemy = (Enemy)cast.GetFirstActor("enemy");
            Goal goal = (Goal)cast.GetFirstActor("goal");
            Score score = (Score)cast.GetFirstActor("score");
            
            

            //start timer
            MyTimer frameCount = new MyTimer();
            
            //gameloop
            while (videoService.IsWindowOpen())
            {
                // only execute input commands if the game isn't over
                if (handle_Player_Enemy_Collision.isGameOver == false)
                {
                    ExecuteActions("input", cast, script);
                    ExecuteActions("update", cast, script);
                    ExecuteActions("output", cast, script);
                }
                //what to do if the player dies
                ///ExecuteActions("inputInGameOver", cast, script);
                ///ExecuteActions("updateInGameOver", cast, script);
                ///ExecuteActions("outputInGameOver", cast, script);
            }
            videoService.CloseWindow();
            Raylib.CloseAudioDevice();
            Raylib.UnloadTexture(dino.TextureR);
            Raylib.UnloadTexture(dino.TextureL);
            Raylib.UnloadTexture(enemy.TextureR);
            Raylib.UnloadTexture(enemy.TextureL);
            Raylib.UnloadTexture(goal.Texture);
            Raylib.UnloadTexture(background.Texture);
            Raylib.UnloadImage(score.scoreBackgroundImage);
            Raylib.UnloadTexture(score.scoreBackgroundTexture);

            
            
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