using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace spaceInvaders
{
    public class Bullet
    {
        private int xPosShoot = 0;
        private int yPosShoot = 0;
        private string skin = "*";
        //private Type shipType;

        public Bullet(int xPos, int yPos)
        {
            xPosShoot = xPos + 2;
            yPosShoot = yPos;
            //this.shipType = shipType;
        }

        public void FireUp(object sender, EventArgs e)
        {
            yPosShoot--;
            Console.SetCursorPosition(xPosShoot, yPosShoot);
            Console.Write(skin);
            // initial x, y position, area size, area height, final x, y position
            Console.MoveBufferArea(xPosShoot, yPosShoot, skin.Length, 1, xPosShoot, yPosShoot - 1);
        }

        public void FireDown()
        {
            yPosShoot++;
            Console.SetCursorPosition(xPosShoot, yPosShoot);
            Console.Write(skin);
            // initial x, y position, area size, area height, final x, y position
            Console.MoveBufferArea(xPosShoot, yPosShoot, skin.Length, 1, xPosShoot, yPosShoot + 1);
        }

        public int GetXPosShoot()
        {
            return xPosShoot;
        }

        public int GetYPosShoot()
        {
            return yPosShoot;
        }

    }
}
