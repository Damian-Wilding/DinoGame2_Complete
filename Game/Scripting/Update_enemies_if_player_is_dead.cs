using DinoGame2.Game.Casting;

namespace DinoGame2.Game.Scripting
{
    public class Update_enemies_if_player_is_dead : Action
    {

        public Update_enemies_if_player_is_dead()
        {
            
        }

        public void Execute(Cast cast, Script script)
        {
            //List<Actor> actors = cast.GetAllActors();
            List<Actor> enemies = cast.GetActors("enemies");
            foreach (Actor actor in enemies)
            {
                
                actor.MoveNext();
                
            }

        
        }
    }
}