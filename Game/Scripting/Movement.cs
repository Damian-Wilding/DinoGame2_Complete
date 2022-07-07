using System.Collections.Generic;
using DinoGame2.Game.Casting;
using DinoGame2.Game.Services;


namespace DinoGame2.Game.Scripting
{
    /// <summary>
    /// <para>An update action that moves all the actors.</para>
    /// <para>
    /// The responsibility of Movement is to move all the actors.
    /// </para>
    /// </summary>
    public class Movement : Action
    {
        /// <summary>
        /// Constructs a new instance of Movement.
        /// </summary>
        public Movement()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            List<Actor> actors = cast.GetAllActors();
            foreach (Actor actor in actors)
            {
                actor.MoveNext();
            }
        }
    }
}