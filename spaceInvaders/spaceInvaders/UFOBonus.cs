using System;
using System.Threading;

namespace spaceInvaders
{
    public class UFOBonus:Ennemy
	{
		private const int HEIGHT_UFO_BONUS = 1; // Ufo's height
        private const int INTERVAL = 200; // Timer interval (ufo's speed)
        private const int XSPAWN = 0; // Value of axis X when ufo spawn
        private int bonusSize = 5; // Ufo's size
        TimeCtrl bonusTimer = new TimeCtrl(INTERVAL); // Timer event to move the Bonus enemys

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lives"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="skin"></param>
        /// <param name="isAlive"></param>
        public UFOBonus(int lives, int xPos, int yPos, string skin, bool isAlive):base(lives, xPos, yPos, skin, isAlive)
		{
            
        }

		/// <summary>
		/// Print a bonus ship
		/// </summary>
		public void Spawn()
		{
			Console.SetCursorPosition(xPos, yPos);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(skin);
            Console.ForegroundColor = ConsoleColor.Gray;

            // Add the Move method to the envent, the method will run each 'INTERVAL' milisecond
            bonusTimer.timeUp += Move;
        }

        /// <summary>
        /// Move the bonus enemy ship
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Move(object sender, EventArgs e)
		{
            //Si vrai, déplace le vaisseau jusqu'à la limite
            if (xPos < Console.WindowWidth - skin.Length)
            {
                MoveRight();
            }
            //Si non, écris des espaces + des bouts du vaisseau pour laisser disparaître le vaisseau
            else if (bonusSize > 0)
            {
                if (xPos >= Console.WindowWidth - skin.Length)
                {
                    //valeur X,Y de depart,Taille du vaisseau,hauteur du vaisseau, déplacementX,Y
                    Console.MoveBufferArea(xPos, yPos, bonusSize, SHIPHEIGHT, xPos + 1, yPos);
                    xPos++;
                    bonusSize--;

                }
            }

            if (bonusSize == 0)
            {
                bonusTimer.timeUp -= Move;
                Thread.Sleep(3000);
                xPos = XSPAWN;
                bonusSize = skin.Length;
                Spawn();
            }
		}
	}
}

