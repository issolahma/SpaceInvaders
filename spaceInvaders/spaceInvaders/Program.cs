using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceInvaders
{
    public class Program
    {
        // Create a new key control object for all the classes
        public static Controls ctrl = new Controls();

        static void Main(string[] args)
        {
            Console.SetWindowSize(68, 30);
            Console.SetBufferSize(68, 30);

            // Create a new menu object
            Menu myMenu = new Menu();
            myMenu.PrintTitle();
            myMenu.PrintMenu();

            // Listen if esc is pressed, for all the classes
            ListenToEsc(ctrl);

            // Method to check if a key is presed
            ctrl.CheckPressedKey();
        }

        /// <summary>
        /// Listens when esc button is pressed
        /// </summary>
        /// <param name="ctrl">ctrl</param>
        static void ListenToEsc(Controls ctrl)
        {
            ctrl.escPressed += ReturnToMenu;
        }

        /// <summary>
        /// Returns to menu when esc pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void ReturnToMenu(object sender, EventArgs e)
        {
            // Srop game eventhandler
            ctrl.leftPressed += null;
            ctrl.rightPressed += null;
            ctrl.spacePressed += null;

            Menu myMenu = new Menu();
            myMenu.PrintTitle();
            myMenu.PrintMenu();
        }

    }
}
