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
        private Type shipType;

        public Bullet(int xPos, int yPos, Type shipType)
        {
            xPosShoot = xPos;
            yPosShoot = yPos;
            this.shipType = shipType;
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
            } while (yPosShoot != 21);
        }

        public int GetXPosShoot()
        {
            return xPosShoot;
        }

        public int GetYPosShoot()
        {
            return yPosShoot;
        }

        public Type GetShooterType()
        {
            return shipType;
        }
    }
}
