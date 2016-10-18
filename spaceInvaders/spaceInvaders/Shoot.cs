using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace spaceInvaders
{
    class Shoot
    {
        private int xPosShoot = 0;
        private int yPosShoot = 0;
        private string skin = "*";

        public Shoot(int xPos, int yPos)
        {
            this.xPosShoot = xPos;
            this.yPosShoot = yPos;
        }

        public void FireUp()
        {
            do
            {
                Console.SetCursorPosition(xPosShoot, yPosShoot);
                Console.Write(skin);
                // initial x, y position, area size, area height, final x, y position
                Console.MoveBufferArea(xPosShoot, yPosShoot, skin.Length, 1, xPosShoot, yPosShoot - 1);
                yPosShoot--;
                Thread.Sleep(400);
            } while (yPosShoot >= 4);
        }

        public void FireDown()
        {
            do
            {
                Console.SetCursorPosition(xPosShoot, yPosShoot);
                Console.Write(skin);
                // initial x, y position, area size, area height, final x, y position
                Console.MoveBufferArea(xPosShoot, yPosShoot, skin.Length, 1, xPosShoot, yPosShoot + 1);
                yPosShoot++;
                Thread.Sleep(400);
            } while (yPosShoot <= 21);
        }
    }
}
