using System;

namespace spaceInvaders
{
	public class Game
	{
		private const string UFO_PLAYER = "<xYx>";
		private const string UFO_BONUS = "<=&=>";
		private const string UFO_ENEMY3 = "]o[";
		private const string UFO_ENEMY2 = "}U{";
		private const string UFO_ENEMY1 = "-0-";
		private int lives = 1;
		private bool isAlive = true;
		private int xPosShip = 30;
		private int yPosShip = 21;
		private int xPosEnemy = 10;
		private int yPosEnemy = 6;
		private int xPosBonusEnemy = 0;
		private int yPosBonusEnemy = 4;

		public Game ()
		{
		}

		public void KeyListener(Controls ctrl)
		{
			
		}

		public void InitGame()
		{
			Console.Clear();
			//Affiche scores et vies
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("\n   Score : ");

			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write("0                              ");

			Console.ForegroundColor = ConsoleColor.White;
			Console.Write("Lives ");

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("{0} {0} {0}\n", UFO_PLAYER);

			//Vaisseau joueur
			Ship playerShip = new Ship(lives, xPosShip, yPosShip, UFO_PLAYER, isAlive);
			playerShip.SpawnPlayer();
			playerShip.KeyListener(Program.ctrl);


			//Place les ennemis
			Console.ForegroundColor = ConsoleColor.White;
			Ennemy[,] ufo3 = new Ennemy[5, 11];
			for (int i = 0; i < 5; i++)
			{
				xPosEnemy = 10;
				for (int j = 0; j < 11; j++)
				{
					switch (i)
					{
					case 0:
						ufo3[i, j] = new Ennemy(lives, xPosEnemy, yPosEnemy, UFO_ENEMY3, isAlive);
						break;
					case 1:
					case 2:
						ufo3[i, j] = new Ennemy(lives, xPosEnemy, yPosEnemy, UFO_ENEMY2, isAlive);
						break;
					case 3:
					case 4:
						ufo3[i, j] = new Ennemy(lives, xPosEnemy, yPosEnemy, UFO_ENEMY1, isAlive);
						break;
					default:
						break;
					}
					xPosEnemy += 4;
				}
				yPosEnemy += 1;
			}
			foreach (Ennemy ufo in ufo3)
			{
				ufo.PrintEnnemy();
			}

			UFOBonus ufoBonus = new UFOBonus(lives, xPosBonusEnemy, yPosBonusEnemy, UFO_BONUS, isAlive);
			ufoBonus.Spawn();
		}
	}
}

