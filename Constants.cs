using System;
using Microsoft.VisualBasic;
using DinoGame2.Game.Casting;

namespace DinoGame2.Game
{
    /// <summary>
    /// <para>The general stuff that makes the window and game</para>
    /// <para>
    /// yee
    /// </para>
    /// </summary>
    public class Constants
    {
        //Initialize the 
        public static int COLUMNS = 40;
        public static int ROWS = 40; // not sure why this stuff -> doesnt work (MAX_Y / CELL_SIZE) - ((MAX_Y / CELL_SIZE)% CELL_SIZE);
        public static int CELL_SIZE = 15;
        public static int MAX_X = 900;
        public static int MAX_Y = 600;
        public static int FRAME_RATE = 60;
        public static int FONT_SIZE = 15;
        public static int DinoAndEnemyFont_Size = FONT_SIZE * 3;
        public static string CAPTION = "Dino Game 2.0";
        public static Point DinoSpawn = new Point (MAX_X / 2, MAX_Y - DinoAndEnemyFont_Size);
        public static int GoalPoints = 1;
        public static Point GoalPosition = new Point(0, FONT_SIZE);
        public static Point GameOverMessagePosition = new Point (MAX_X / 2, MAX_Y / 2);
        // (Might use this later, but I dont think it will be needed) public static string GameOverMessage = "Game Over"
        public static int Enemy_Top_Row = GoalPosition.GetY() * (DinoAndEnemyFont_Size / FONT_SIZE); //30
        public static int Enemy_Bottom_Row = ROWS * FONT_SIZE - ((DinoAndEnemyFont_Size) * 3); // 40 * 15 - 

        public static Point scorePosition = new Point(100,0);

        // Lets make some colors to use in the beta.
        public static Color RED = new Color(255, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color YELLOW = new Color(255, 255, 0);
        public static Color GREEN = new Color(0, 255, 0);
        public static Color ORANGE = new Color(255, 165, 0);
        public static Color BLUE = new Color(0, 255, 255);
        public static Color BLACK = new Color(0, 0, 0);
    }
}