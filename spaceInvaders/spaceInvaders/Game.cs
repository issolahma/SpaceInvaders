using System;
using System.Threading;

namespace spaceInvaders
{
	public class Game
	{
        // Ship's skins
		private const string UFO_PLAYER = "<xYx>";
		private const string UFO_BONUS = "<=&=>";
		private const string UFO_ENEMY3 = "]o[";
		private const string UFO_ENEMY2 = "}U{";
		private const string UFO_ENEMY1 = "-0-";

        //Life status of the ships
        private bool isAlive = true;

        //Speed of the basics enemy
        private const int INTERVALENEMY = 1000;
        private const int INTERVALBONUS = 200; // Timer interval (ufo's speed)
        //Positions of all the ships
        private const int xPosBonusEnemy = 0;
        private const int yPosBonusEnemy = 4;
		private int xPosShip = 30;
		private int yPosShip = 21;
		private int xPosEnemy = 10;
		private int yPosEnemy = 6;
		
        //Array of basics enemy
        private Ennemy[,] ufo3 = new Ennemy[5, 11];
        //Variable to say if enemy goes right or left
        private bool goLeft = false;

        //Create a bonus enemy(red one)
        UFOBonus ufoBonus;

        // Timer to move the enemys
        TimeCtrl enemyTimer = new TimeCtrl(INTERVALENEMY);
        public TimeCtrl bonusTimer = new TimeCtrl(INTERVALBONUS); // Timer event to move the Bonus enemys

        // Create player, and enemy bullet
        private Bullet playerBullet;
        private Bullet enemysBullet;

        /// <summary>
        /// Init the base of the game, screen, scores...
        /// </summary>
        public void InitGame()
		{
			Console.Clear();
			
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("\n   Score : ");

			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("0                              ");

			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("Lives ");

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("{0} {0} {0}\n", UFO_PLAYER);

			//Create player's ship, and make it spawn on the screen
			Program.playerShip = new Ship(xPosShip, yPosShip, UFO_PLAYER, isAlive);
			Program.playerShip.SpawnPlayer();


			//Create all the basics enemys
			Console.ForegroundColor = ConsoleColor.White;
			
			for (int i = 0; i < 5; i++)
			{
				xPosEnemy = 10;
				for (int j = 0; j < 11; j++)
				{
					switch (i)
					{
					case 0:
						ufo3[i, j] = new Ennemy(xPosEnemy, yPosEnemy, UFO_ENEMY3, isAlive);
						break;
					case 1:
					case 2:
						ufo3[i, j] = new Ennemy(xPosEnemy, yPosEnemy, UFO_ENEMY2, isAlive);
						break;
					case 3:
					case 4:
						ufo3[i, j] = new Ennemy(xPosEnemy, yPosEnemy, UFO_ENEMY1, isAlive);
						break;
					default:
						break;
					}
					xPosEnemy += 4;
				}
				yPosEnemy += 1;
			}
            //Print all the basics enemys
            foreach (Ennemy ufo in ufo3)
            {
                ufo.PrintEnnemy();
            }

            //Make the bonus enemy spawn on the screen
            ufoBonus = new UFOBonus(xPosBonusEnemy, yPosBonusEnemy, UFO_BONUS, isAlive);
			ufoBonus.Spawn();
		}

        /// <summary>
        /// Start the game
        /// </summary>
        public void startGame()
        {
            ColisionDetector colDetect = new ColisionDetector(ufoBonus, ufo3, Program.playerShip, playerBullet, enemysBullet);
            /* Créer un nouveau thread pour la detection des touches http://www.tutorialspoint.com/csharp/csharp_multithreading.htm */
            ThreadStart colDetectREF = new ThreadStart(colDetect.ActivDetection);
            Thread coliDetect = new Thread(colDetectREF);
            //coliDetect.Start(); trop lent--------------------------
            /*colDetect.ActivDetection();*/

            enemyTimer.timeUp += MoveAllEnemy; 
            bonusTimer.timeUp += ufoBonus.Move;
            ufoBonus.isInTheEnd += stopBonusTimer;
            ufoBonus.timeToRespawn += startBonus;
            colDetect.kaboum += DestroyShip;
        }

        /// <summary>
        /// Stop the game
        /// </summary>
        public void stopGame(object sender, EventArgs e)
        {
            enemyTimer.timeUp -= MoveAllEnemy;
            bonusTimer.timeUp -= ufoBonus.Move;
        }

        /// <summary>
        /// Move all the basics enemys in the right direction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MoveAllEnemy(object sender, EventArgs e)
        {
            // Check if the enemy have to change their direction
            foreach (Ennemy ufo in ufo3)
            {
                //X position == 1 -> they have to go to the right
                if ((ufo.GetXPos() == 1) && (goLeft))
                {
                    goLeft = false;
                }
                //X position == windows size -> they have to go to the left
                else if ((ufo.GetXPos() == Console.WindowWidth-(UFO_ENEMY1.Length+1)) && (!goLeft))
                {
                    goLeft = true;
                }
            }

            //Make the enemys move to the direction they have to
            foreach (Ennemy ufo in ufo3)
            {
                if (goLeft)
                {
                    ufo.MoveLeft();
                }
                else
                {
                    ufo.MoveRight();
                }
            }
          
        }

        private void stopBonusTimer(object sender, EventArgs e)
        {
            bonusTimer.timeUp -= ufoBonus.Move;
        }

        private void startBonus(object sender, EventArgs e)
        {
            bonusTimer.timeUp += ufoBonus.Move;
            ufoBonus.Spawn();
        }

        private void DestroyShip(object sender, ColDetectEventArgs e)
        {
            ShipMasterClass deadShip = e.ship;
            deadShip = null;
        }

    }
}

