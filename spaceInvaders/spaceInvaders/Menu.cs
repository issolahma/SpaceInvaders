using System;
using System.Threading;

namespace spaceInvaders
{
    public class MenuEventArgs:EventArgs
    {
        public int MenuIndex { get; set; }
    }

    public class Menu
	{
		private int menuIndex = 0;  // Menu we are in
		private string[] menuArray = new string[5] { "Jouer", "Options", "Highscore", "A propos", "Quitter" }; 
		private int Y = 2; // Line to write the title
        public event EventHandler<MenuEventArgs> menuSelected; //Event to tell which choise has been made

        /// <summary>
        /// Print the menu's title
        /// </summary>
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

        /// <summary>
        /// Print the menu with yellow color for selected entry
        /// </summary>
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

        /// <summary>
        /// Select menu upside, done when up arrow is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MenuSelectUp(object sender, EventArgs e)
		{
            // If menuIndex == 0 we are at the top -> do nothing, if else decrease the index
            if (menuIndex != 0) {
				menuIndex -= 1;
				PrintMenu ();
			}
		}

        /// <summary>
        /// Select menu downside, done when down arrow is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public void MenuSelectDown(object sender, EventArgs e)
		{
            // If menuIndex == 4 we are down -> do nothing, if else increase the index
            if (menuIndex != 4) {
				menuIndex += 1;
				PrintMenu ();
			}
		}

        /// <summary>
        /// When enter is pressed ruin the event OnMenuSelected 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public void MenuSelectEnter(object sender, EventArgs e)
		{
            OnMenuSelected(menuIndex);
		}

        /// <summary>
        /// Event when a menu is selected
        /// </summary>
        /// <param name="menuIndex"></param>
        protected virtual void OnMenuSelected(int menuIndex)
        {
            menuSelected?.Invoke(this, new MenuEventArgs() {MenuIndex = menuIndex });
        }
	}
}

