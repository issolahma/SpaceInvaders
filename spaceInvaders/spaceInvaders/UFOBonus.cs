using System;
using System.Timers;

namespace spaceInvaders
{
	public class UFOBonus:Ennemy
	{
		//private const string skin = "<=&=>"; //Skin du vaisseau bonus
		private const int INTERVAL_UFO_BONUS = 100; //nombre de milesonde pour un tic (déplacement de l'UFO)     
		private const int INTERVAL_RANDOM_MAX_UFO_BONUS = 60000; //nombre de milesonde pour un tic maximum (time for respawn UFOBonus)
		private const int WIDTH_UFO_BONUS = 5; //Largeur en charactère de l'UFO
		private const int HEIGHT_UFO_BONUS = 1;//Hauteur en charactère de l'UFO
		//private const int yPos = 4; //Position de l'UFO bonus, la ligne
		private int positionLeftUFOBonus = 0;//Position sur la ligne de l'UFO 
		private int positionLeftUFOBonusI = 0;//Indice qui sert à écrir le nombre d'espace avant l'UFO, sert au déplacement de celui-ci
		Random intervalRespawn = new Random();//interval généré pour faire respown le vaisseau bonus
		Timer timerUFOBonus = new Timer();//Timer pour le déplacement
		Timer timerRandomUFOBonus = new Timer();//Timer pour le respawn

		/// <summary>
		/// Construceur sans propriété
		/// </summary>
		public UFOBonus(int lives, int xPos, int yPos, string skin, bool isAlive):base(lives, xPos, yPos, skin, isAlive)
		{ }

		/// <summary>
		/// Fait spawn un bonus
		/// </summary>
		public void Spawn()
		{
			//Fait pop le vaisseau
			Console.SetCursorPosition(xPos, yPos);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write(skin);

			//Appelle la méthode de déplacement
			Move();
		}

		/// <summary>
		/// Arrête le timer
		/// </summary>
		private void Respawn(object source, ElapsedEventArgs e)
		{
			//Désactive le timer pour pas qu'il respawn un deuxième en même temps
			timerRandomUFOBonus.Enabled = false;

			//Crée un nouveau vaisseau
			//UFOBonus newUFO = new UFOBonus(); //--------------------------------????----------------------------------------------
			this.Spawn();
		}

		/// <summary>
		/// Déplacement du vaisseau
		/// </summary>
		public void Move()
		{
			//proprité du timer déplacement de l'ufo bonus
			timerUFOBonus.Elapsed += new ElapsedEventHandler(TimerUFOBonusElapsed);//Méthode à appeler à chaque tic pour déplacé le vaisseau bonus
			timerUFOBonus.Interval = INTERVAL_UFO_BONUS; //Intervalle en miliseconde
			timerUFOBonus.Enabled = true;
		}

		/// <summary>
		/// Méthode effectuée à chaque tic pour déplacé le vaisseau bonus
		/// </summary>
		private void TimerUFOBonusElapsed(object source, ElapsedEventArgs e)
		{
			//Si vrai, déplace le vaisseau jusqu'à la limite
			if (positionLeftUFOBonus < Console.WindowWidth - WIDTH_UFO_BONUS)
			{
				Console.MoveBufferArea(positionLeftUFOBonus, yPos, WIDTH_UFO_BONUS, HEIGHT_UFO_BONUS, positionLeftUFOBonus + 1, yPos);
				positionLeftUFOBonus++;
			}
			//Si non, écris des espaces + des bouts du vaisseau pour laisser disparaître le vaisseau
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				//déplace le curseur au premier caractère du vaisseau
				Console.SetCursorPosition(Console.WindowWidth -skin.Length, yPos);

				//Boucle qui écris le nombre de espace
				for (int i = 0; i < positionLeftUFOBonusI; i++)
				{
					Console.Write(" ");
				}
				//Puis écris un bout du vaisseau
				for (int i = 0; i <skin.Length - positionLeftUFOBonusI; i++)
				{
					Console.Write(skin[i]);
				}

				//Augmente l'indice pour décaler
				positionLeftUFOBonusI++;

				//Quand il disparaît (restant un petit bout)
				if (positionLeftUFOBonusI ==skin.Length)
				{
					//On cache le bout
					Console.SetCursorPosition(Console.WindowWidth - 1, yPos);
					Console.Write(" ");

					//Désactive le timer
					timerUFOBonus.Enabled = false;

					//Faire respawn un bonus
					//proprité du timer déplacement de l'ufo bonus
					timerRandomUFOBonus.Elapsed += new ElapsedEventHandler(Respawn);//Méthode à appeler après le tic
					timerRandomUFOBonus.Interval = intervalRespawn.Next(INTERVAL_RANDOM_MAX_UFO_BONUS); //Intervalle en miliseconde
					timerRandomUFOBonus.Enabled = true;
				}

			}
		}
	}
}

