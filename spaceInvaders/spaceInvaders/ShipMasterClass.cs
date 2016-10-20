using System;

namespace spaceInvaders
{
    public class ShipMasterClass
    {
        protected int lives = 0;
        protected int xPos = 0;
        protected int yPos = 0;
        protected string skin = "";
        protected bool isAlive = true;
        protected const int SHIPHEIGHT = 1;

        protected ShipMasterClass (int lives, int xPos, int yPos, string skin, bool isAlive)
		{
			this.lives = lives;
			this.xPos = xPos;
			this.yPos = yPos;
			this.skin = skin;
			this.isAlive = isAlive;
		}

		public void MoveLeft()
		{
			if (xPos < Console.WindowWidth - skin.Length)
			{
				//valeur X,Y de depart,Taille du vaisseau,hauteur du vaisseau, déplacementX,Y
				Console.MoveBufferArea(xPos, yPos, skin.Length, SHIPHEIGHT, xPos - 1, yPos);
				xPos--;
			}
		}

		public void MoveRight()
		{
			if (xPos < Console.WindowWidth - skin.Length)
			{
				//valeur X,Y de depart,Taille du vaisseau,hauteur du vaisseau, déplacementX,Y
				Console.MoveBufferArea(xPos, yPos, skin.Length, SHIPHEIGHT, xPos + 1, yPos);
				xPos++;
			}
		}

        protected void EnemyGoDown()
		{

		}

		protected void Fire()
		{

		}

        public int GetXPos()
        {
            return xPos;
        }

        public int GetYPos()
        {
            return yPos;
        }
    }
}

