using System;
using System.Timers;

namespace spaceInvaders
{
    public class Ennemy : ShipMasterClass
    {
        

		// Constructor
		public Ennemy(int lives, int xPos, int yPos, string skin, bool isAlive):base(lives, xPos, yPos, skin, isAlive)
		{
         
		}

		// Print ennemy
		public void PrintEnnemy()
		{
			Console.SetCursorPosition(xPos, yPos);
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(skin);
		}
    }
}

