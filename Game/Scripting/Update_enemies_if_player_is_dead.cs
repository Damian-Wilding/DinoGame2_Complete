using DinoGame2.Game.Casting;
using DinoGame2.Game.Services;

namespace DinoGame2.Game.Scripting
{
    public class Update_enemies_if_player_is_dead : Action
    {

        private int count;
        private SoundService soundService;

        public Update_enemies_if_player_is_dead(SoundService soundService)
        {
            this.soundService = soundService;
            count = 0;
        }

        public void Execute(Cast cast, Script script)
        {
            //List<Actor> actors = cast.GetAllActors();
            List<Actor> enemies = cast.GetActors("enemy");
            foreach (Actor actor in enemies)
            {
                
                actor.MoveNext();
                
            }

            if (this.count == 0)
            {
                this.soundService.PlaySound(this.soundService.ExplosionSound);
            }

            count += 1;
        }
    }
}