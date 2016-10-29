using System;

namespace spaceInvaders
{
    public class ShipMasterClass
    {
        protected int xPos = 0;
        protected int yPos = 0;
        protected string skin = "";
        protected bool isAlive = true;
        protected const int SHIPHEIGHT = 1;

        protected ShipMasterClass (int xPos, int yPos, string skin, bool isAlive)
		{
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

        //public void Fire(object sender, EventArgs e)
        //{
        //    Bullet shipShoot = new Bullet(xPos + 2, yPos - 1, this.GetType());
        //    if (GetType() == typeof(Ship))
        //    {
        //        shipShoot.FireUp();
        //    }
        //    else
        //    {
        //        shipShoot.FireDown();
        //    }
        //}

        public int GetXPos()
        {
            return xPos;
        }

        public int GetYPos()
        {
            return yPos;
        }

        public void SetIsAlive(bool value)
        {
            isAlive = value;
        }
    }
}

