using System;

namespace DinoGame2.Game.Services{
    
    
    public class Timer
    {
        public int newLevelTimer = 0;

        public Timer()
        {
            
        }

        public void TimerUpdate()
        {
            this.newLevelTimer += 1;
        }

        public void TimerReset()
        {
            this.newLevelTimer = 0;
        }
    }
}