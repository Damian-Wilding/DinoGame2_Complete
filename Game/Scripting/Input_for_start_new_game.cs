using DinoGame2.Game.Services;
using DinoGame2.Game.Casting;

namespace DinoGame2.Game.Scripting
{
    public class Input_for_start_new_game : Action
    {
        private KeyboardService keyboardService;
        public bool IsNewGameStarting = false;
        public bool Input_For_Start_New_Game(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
            return this.IsNewGameStarting;
        }

        public void Execute(Cast cast, Script script)
        {
            if (this.keyboardService.IsKeyDown("enter") == true)
            {
                //the player has pressed ENTER. time to start a new game
                this.IsNewGameStarting = false;
            }
            
        }
    }












}