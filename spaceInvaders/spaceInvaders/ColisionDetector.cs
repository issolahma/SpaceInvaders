using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceInvaders
{
    class ColisionDetector
    {
        private int xBullet = 0;
        private int yBullet = 0;
        private int xShip = 0;
        private int yShip = 0;
        private string shooterType = "";
        public event EventHandler kaboum;

        public ColisionDetector(int xBullet, int yBullet, int xShip, int yShip, string shooterType)
        {
            this.xBullet = xBullet;
            this.yBullet = yBullet;
            this.xShip = xShip;
            this.yShip = yShip;
        }

        public void ActivDetection()
        {
            do
            {
                
            } while ((xBullet != xShip) && (yBullet != yShip));
            Boom();
        }

        protected virtual void Boom()
        {
            kaboum?.Invoke(this, new EventArgs());
        }
    }
}
