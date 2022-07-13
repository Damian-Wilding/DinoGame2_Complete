using System;

namespace DinoGame2.Game.Services{
    
    
    public class MyTimer
    {
        public int time;
        public int framerate;
        public int seconds;

        public MyTimer()
        {
            this.time = 0;
            this.framerate = Constants.FRAME_RATE;
            this.seconds = 0;
        }

        public void TimerUpdate()
        {
            this.time += 1;
        }

        public void TimerReset()
        {
            this.time = 0;
        }

        public void CountSeconds()
        {
            TimerUpdate();
            if (this.time == this.framerate)
            {
                TimerReset();
                this.seconds += 1;
            }
        }
        public int CalculateFramesPerImage(int amountOfSprites, float animationTime)
        {
            float framesPerImageAsFloat = animationTime / amountOfSprites;
            int framesPerImageAsINT = Convert.ToInt32(framesPerImageAsFloat);
            return framesPerImageAsINT;
        }
    }
}