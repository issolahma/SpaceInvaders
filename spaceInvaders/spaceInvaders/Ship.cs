using System;

namespace spaceInvaders
{
	public class Ship:ShipMasterClass
	{

		public Ship(int xPos, int yPos, string skin, bool isAlive):base(xPos, yPos, skin, isAlive)
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

        public void Fire(object sender, EventArgs e)
        {
            Program.playerBullet = new Bullet(xPos, yPos);
            TimeCtrl bulletTimer = new TimeCtrl(400);
            bulletTimer.timeUp += Program.playerBullet.FireUp;
        }  
    }
}

