using System;

namespace spaceInvaders
{
	public class Ennemy:ShipMasterClass
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

		// Move left
		public void MoveLeft()
		{
			xPos -= 2;
		}

		// Move right
		public void MoveRight()
		{
			xPos += 2;
		}
	}
}

