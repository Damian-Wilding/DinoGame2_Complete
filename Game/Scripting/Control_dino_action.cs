using DinoGame2.Game.Casting;
using DinoGame2.Game.Services;


namespace DinoGame2.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the Dino.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the Dino in that direction.
    /// </para>
    /// </summary>
    public class Control_dino_action : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(0, 0);
        Dino? dino;
        Bullet? bullet;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public Control_dino_action(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            //this.cast = cast;
            dino = (Dino)cast.GetFirstActor("dino");
            // left
            if (keyboardService.IsKeyDown("left"))
            {
                if (dino.GetPosition().GetX() > 10)
                {
                    direction = new Point(-Constants.CELL_SIZE, 0);
                    //System.Console.WriteLine("moving left");
                }
                else
                {
                    direction = new Point(0, 0);
                }
                
                
            }

            // right
            else if (keyboardService.IsKeyDown("right"))
            {
                if (dino.GetPosition().GetX() < Constants.MAX_X - dino.GetFontSize())
                {
                    direction = new Point(Constants.CELL_SIZE, 0);
                    //System.Console.WriteLine("moving left");
                }
                else
                {
                    direction = new Point(0, 0);
                }
            }

            // down
            else if (keyboardService.IsKeyDown("down"))
            {
                if (dino.GetPosition().GetY() < Constants.DinoSpawn.GetY())
                {
                    direction = new Point(0, Constants.CELL_SIZE);
                    //System.Console.WriteLine("moving left");
                }
                else
                {
                    direction = new Point(0, 0);
                }
            }

            // up
            else if (keyboardService.IsKeyDown("up"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
                //System.Console.WriteLine("moving up");
            }

            //none
            else
            {
                direction = new Point(0, 0);
                //System.Console.WriteLine("not moving");
            }
            
            dino.SetVelocity(direction);

            if (keyboardService.IsKeyDown("space"))
            {
                this.bullet = new Bullet(cast);
                cast.AddActor("bullet", bullet);
            }
        }
    }
} 