using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceInvaders
{
    public class Program
    {
        // Create a new key control object for all the classes (esc button)
        public static Controls ctrl = new Controls();
        private static Menu myMenu;
        public static Ship playerShip;
        public static Game myGame;

        static void Main(string[] args)
        {
            Console.SetWindowSize(68, 30);
            Console.SetBufferSize(68, 30);
            Console.CursorVisible = false;
            //Global esc key listener
            ctrl.escPressed += GoToMenu;
            // Create a new menu
            GoToMenu(null, null);

            ctrl.RunCheckKeys();
        }

        /// <summary>
        /// Returns to menu when esc pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void GoToMenu(object sender, EventArgs e)
        {
            // Create a new menu object
            myMenu = new Menu();
            myMenu.PrintTitle();
            myMenu.PrintMenu();

            if (playerShip != null)
            {
                //remove game's keys events
                ctrl.leftPressed -= playerShip.MoveLeft;
                ctrl.rightPressed -= playerShip.MoveRight;
                ctrl.spacePressed -= playerShip.Fire;
            }

            //Add usefull keys events
            ctrl.upPressed += myMenu.MenuSelectUp;
            ctrl.downPressed += myMenu.MenuSelectDown;
            ctrl.enterPressed += myMenu.MenuSelectEnter;
            myMenu.menuSelected += GoToChoosenMenu;
        }

        /// <summary>
        /// Go to the selected menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">menu index from class Menu</param>
        static void GoToChoosenMenu(object sender, MenuEventArgs e)
        {
            int menuIndex = e.MenuIndex;
           
            switch (menuIndex)
            {
                case 0://Jouer
                    //Stop menu keys events
                    ctrl.upPressed -= myMenu.MenuSelectUp;
                    ctrl.downPressed -= myMenu.MenuSelectDown;
                    ctrl.enterPressed -= myMenu.MenuSelectEnter;

                    //init and start a new game
                    myGame = new Game();
                    ctrl.escPressed += myGame.stopGame;
                    myGame.InitGame();
                    myGame.startGame();
                    break;
                case 1:
                    //Options
                    break;
                case 2:
                    //Highscore
                    break;
                case 3://A propos
                    var aProppos = new Apropos();
                    aProppos.printText();
                    break;
                case 4://Quitter
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

    }
}
