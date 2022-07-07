using System;

namespace DinoGame2.Game.Casting
{
    public class Goal : Actor
    {
        public int GoalsHitBoxY = Constants.GoalPosition.GetY() +30;
        public int points = Constants.GoalPoints;
        public Goal()
        {
            MakeTheGoal();
        }
       
        public void MakeTheGoal()
        {
            this.SetColor(Constants.YELLOW);
            //this.SetPosition(new Point(1,0));
            this.SetText("___________________________________________________________________");
            this.SetVelocity(new Point(0,0));
            this.SetFontSize(Constants.DinoAndEnemyFont_Size);
            this.SetPosition(Constants.GoalPosition);
        }
    }
}