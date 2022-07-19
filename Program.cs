using DinoGame2.Game.Casting;
using DinoGame2.Game.Directing;
using DinoGame2.Game.Scripting;
using DinoGame2.Game.Services;
//using Raylib_cs;


namespace DinoGame2.Game
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
            SoundService soundService = new SoundService();
            videoService.OpenWindow();

            //creating the cast
            Cast cast = new Cast();
            Cast CastTextures = new Cast();
            cast.AddActor("dino", new Dino());
            cast.AddActor("enemy", new Enemy());
            //cast.AddActor("enemy", new Enemy());
            cast.AddActor("score", new Score());
            cast.AddActor("goal", new Goal());
            cast.AddActor("background", new Background());
            //cast.AddActor("bullet", new Bullet());

            
            //MyTimer frameCount = new MyTimer();

            //creating the script
            Script script = new Script();

            Handle_player_enemy_collision handle_player_enemy_collision = new Handle_player_enemy_collision();
            Input_For_Start_New_Game input_For_Start_New_Game = new Input_For_Start_New_Game(keyboardService);

            script.AddAction("input", new Control_dino_action(keyboardService));
            script.AddAction("update", handle_player_enemy_collision);
            script.AddAction("update", new Handle_player_goal_collision());
            script.AddAction("update", new Handle_bullet_enemy_collision(soundService));
            script.AddAction("update", new Movement());
            script.AddAction("output", new Draw_actors(videoService));
            script.AddAction("inputInGameOver", input_For_Start_New_Game);
            script.AddAction("updateInGameOver", new Update_enemies_if_player_is_dead(soundService));
            script.AddAction("outputInGameOver", new Draw_actors_if_player_is_dead(videoService));
            
            //start the game
            Director director = new Director(videoService, handle_player_enemy_collision, input_For_Start_New_Game, soundService);
            director.StartGame(cast, script);
        }
    }
}