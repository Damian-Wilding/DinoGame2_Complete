using DinoGame2.Game.Casting;
using DinoGame2.Game.Services;

namespace DinoGame2.Game.Scripting
{
    public class Handle_bullet_enemy_collision : Action
    {
        List<List<Point>> allEnemiesHitboxList = new List<List<Point>>();
        List<List<Point>> allBulletsHitboxList = new List<List<Point>>();
        public SoundService soundService;

        //public List<Point> explosionPoints = new List<Point>();
        public Handle_bullet_enemy_collision(SoundService soundService)
        {
            this.soundService = soundService;
        }

        public void Execute(Cast cast, Script script)
        {
            List<Actor> enemies = cast.GetActors("enemy");
            Dino dino = (Dino)cast.GetFirstActor("dino");
            Score score = (Score)cast.GetFirstActor("score");
            Goal goal = (Goal)cast.GetFirstActor("goal");
            List<Actor> bullets = cast.GetActors("bullet");

            //checks to see if any of the enemies are touching any of the fireballs

            //first we clear out the enemy hitbox list then fill it out again
            allEnemiesHitboxList.Clear();
            foreach (Enemy enemy in enemies)
            {
                enemy.SetHitboxList();
                allEnemiesHitboxList.Add(enemy.GetHitboxList());
            }

            // then we do the same thing with the bullets hitbox list
            allBulletsHitboxList.Clear();
            foreach (Bullet bullet in bullets)
            {
                bullet.SetHitboxList();
                allBulletsHitboxList.Add(bullet.GetHitboxList());
            }

            foreach (Enemy enemy in enemies)
            {
                enemy.SetHitboxList();
                Point enemyPosition_TopLeft = enemy.enemyHitboxList[0];
                Point enemyPosition_BottomRight = enemy.enemyHitboxList[3];
                Point enemyPosition_BottomLeft = enemy.enemyHitboxList[1];
                Point enemyPosition_TopRight = enemy.enemyHitboxList[2];

                int enemyPosition_TopLeftX = enemyPosition_TopLeft.GetX();
                int enemyPosition_TopLeftY = enemyPosition_TopLeft.GetY();
                int enemyPosition_BottomRightX = enemyPosition_BottomRight.GetX();
                int enemyPosition_BottomRightY = enemyPosition_BottomRight.GetY();
                int enemyPosition_TopRightX = enemyPosition_TopRight.GetX();
                int enemyPosition_TopRightY = enemyPosition_TopRight.GetY();
                int enemyPosition_BottomLeftX = enemyPosition_BottomLeft.GetX();
                int enemyPosition_BottomLeftY = enemyPosition_BottomLeft.GetY();

                foreach (Bullet bullet in bullets)
                {
                    bullet.SetHitboxList();
                    Point bulletPosition_TopLeft = bullet.bulletHitboxList[0];
                    Point bulletPosition_BottomRight = bullet.bulletHitboxList[3];
                    Point bulletPosition_BottomLeft = bullet.bulletHitboxList[1];
                    Point bulletPosition_TopRight = bullet.bulletHitboxList[2];

                    int bulletPosition_TopLeftX = bulletPosition_TopLeft.GetX();
                    int bulletPosition_TopLeftY = bulletPosition_TopLeft.GetY();
                    int bulletPosition_BottomRightX = bulletPosition_BottomRight.GetX();
                    int bulletPosition_BottomRightY = bulletPosition_BottomRight.GetY();
                    int bulletPosition_TopRightX = bulletPosition_TopRight.GetX();
                    int bulletPosition_TopRightY = bulletPosition_TopRight.GetY();
                    int bulletPosition_BottomLeftX = bulletPosition_BottomLeft.GetX();
                    int bulletPosition_BottomLeftY = bulletPosition_BottomLeft.GetY();

                    //checks to  see if the enemies top left corner is in the bullet hitbox
                    if (enemyPosition_TopLeftX >= bulletPosition_TopLeftX &&
                        enemyPosition_TopLeftX <= bulletPosition_TopRightX &&
                        enemyPosition_TopLeftY >= bulletPosition_TopLeftY &&
                        enemyPosition_TopLeftY <= bulletPosition_BottomLeftY)
                    {
                        cast.RemoveActor("enemy", enemy);
                        cast.RemoveActor("bullet", bullet);
                        System.Console.WriteLine("gonna die");
                        soundService.PlaySound(soundService.DeathSound);
                        break;
                    }

                    //checks to  see if the enemies bottom right corner is in the bullet hitbox
                    else if (enemyPosition_BottomRightX >= bulletPosition_TopLeftX &&
                        enemyPosition_BottomRightX <= bulletPosition_TopRightX &&
                        enemyPosition_BottomRightY >= bulletPosition_TopLeftY &&
                        enemyPosition_BottomRightY <= bulletPosition_BottomLeftY)
                    {
                        cast.RemoveActor("enemy", enemy);
                        cast.RemoveActor("bullet", bullet);
                        System.Console.WriteLine("gonna die");
                        soundService.PlaySound(soundService.DeathSound);
                        break;
                    }

                    //checks to  see if the enemies top right corner is in the bullet hitbox
                    else if (enemyPosition_TopRightX >= bulletPosition_TopLeftX &&
                        enemyPosition_TopRightX <= bulletPosition_TopRightX &&
                        enemyPosition_TopRightY >= bulletPosition_TopLeftY &&
                        enemyPosition_TopRightY <= bulletPosition_BottomLeftY)
                    {
                        cast.RemoveActor("enemy", enemy);
                        cast.RemoveActor("bullet", bullet);
                        System.Console.WriteLine("gonna die");
                        soundService.PlaySound(soundService.DeathSound);
                        break;
                    }

                    //checks to  see if the enemies bottom left corner is in the bullet hitbox
                    else if (enemyPosition_BottomLeftX >= bulletPosition_TopLeftX &&
                        enemyPosition_BottomLeftX <= bulletPosition_TopRightX &&
                        enemyPosition_BottomLeftY >= bulletPosition_TopLeftY &&
                        enemyPosition_BottomLeftY <= bulletPosition_BottomLeftY)
                    {
                        cast.RemoveActor("enemy", enemy);
                        cast.RemoveActor("bullet", bullet);
                        System.Console.WriteLine("gonna die");
                        soundService.PlaySound(soundService.DeathSound);

                        break;
                    }
                }
            }
        }


    }
}