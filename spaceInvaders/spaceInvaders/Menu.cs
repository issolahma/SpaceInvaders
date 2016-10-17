using System;
using System.Threading;

namespace spaceInvaders
{
	public class Menu
	{
		private int menuIndex = 0;
		private string[] menuArray = new string[5] { "Jouer", "Options", "Highscore", "A propos", "Quitter" };
		private int Y = 2;

		public Menu ()
		{
            this.KeyListener(Program.ctrl);		
		}

        /// <summary>
        /// Listen if menu's usefull keys are pressed
        /// </summary>
        /// <param name="ctrl"></param>
        public void KeyListener(Controls ctrl)
		{
			ctrl.upPressed += MenuSelectUp;
			ctrl.downPressed += MenuSelectDown;
			ctrl.enterPressed += MenuSelectEnter;
		}

		public void PrintTitle ()
		{
			Console.Clear ();
			string title = "Spicy Invader";
			string invaders = "]o[ ]o[       ]o[ ]o[";
			string ship = "<xYx>";

			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.SetCursorPosition ((Console.WindowWidth - invaders.Length) / 2, Y);
			Console.WriteLine (invaders);

			Console.SetCursorPosition ((Console.WindowWidth - ship.Length) / 2, Y + 2);
			Console.WriteLine (ship);

			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition ((Console.WindowWidth - title.Length) / 2, Y + 4);
			Console.WriteLine (title);
			Console.ForegroundColor = ConsoleColor.Gray;
		}

		public void PrintMenu ()
		{
			Y = 12;
			for (int i = 0; i < menuArray.Length; i++) {
				Console.SetCursorPosition ((Console.WindowWidth - menuArray[i].Length) / 2, Y);
				if (menuIndex == i) {
					Console.ForegroundColor = ConsoleColor.Yellow;
				} else {
					Console.ForegroundColor = ConsoleColor.Gray;
				}
				Console.WriteLine (menuArray[i]);
				Console.ForegroundColor = ConsoleColor.Gray;
				Y += 1;
			}
		}

		public void MenuSelectUp(object sender, EventArgs e)
		{
			if (menuIndex != 0) {
				menuIndex -= 1;
				PrintMenu ();
			}
		}

		public void MenuSelectDown(object sender, EventArgs e)
		{
			if (menuIndex != 4) {
				menuIndex += 1;
				PrintMenu ();
			}
		}

		public void MenuSelectEnter(object sender, EventArgs e)
		{
            // Controls to stop outside the menu
            Program.ctrl.upPressed = null;
            Program.ctrl.downPressed = null;
            Program.ctrl.enterPressed = null;

            switch (menuIndex) {
			case 0:
                Game myGame = new Game ();
				myGame.InitGame ();
                myGame.startGame();
				break;
			case 1:
				//Options
				break;
			case 2:
				//Highscore
				break;
			case 3:
				Apropos aPropos = new Apropos ();
				aPropos.printText ();
				break;
			case 4:
				Environment.Exit(0);
				break;
			default:
				break;
			}
		}
	}
}

