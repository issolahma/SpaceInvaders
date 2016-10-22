using System;

namespace spaceInvaders
{
	public class Ship:ShipMasterClass
	{

		public Ship(int lives, int xPos, int yPos, string skin, bool isAlive):base(lives, xPos, yPos, skin, isAlive)
		{
            //Add ship method control to the keys events
            Program.ctrl.leftPressed += MoveLeft;
            Program.ctrl.rightPressed += MoveRight;
            Program.ctrl.spacePressed += Fire;
        }

		public void SpawnPlayer()
		{
			Console.SetCursorPosition(xPos, yPos);
			Console.WriteLine(skin);
		}

        public void MoveLeft(object sender, EventArgs e)
        {
            MoveLeft();
        }

        public void MoveRight(object sender, EventArgs e)
        {
            MoveRight();
        }

        
    }
}

