using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceInvaders
{
    public class ColDetectEventArgs : EventArgs
    {
        public ShipMasterClass ship { get; set; }
    }

    class ColisionDetector
    {
        private int xBullet = 0;
        private int yBullet = 0;
        private Ship player;
        public event EventHandler<ColDetectEventArgs> kaboum;
        List <ShipMasterClass> allEnemyShip = new List<ShipMasterClass>();

        public ColisionDetector(ShipMasterClass ufoBonus, ShipMasterClass[,] ufo, Ship player, Bullet playerBullet, Bullet enemysBullet)
        {
            this.player = player;
            allEnemyShip.Add(ufoBonus);
            foreach(ShipMasterClass ship in ufo)
            {
                allEnemyShip.Add(ship);
            }
        }

        public void ActivDetection()
        {
            while (true){
                foreach (ShipMasterClass ship in allEnemyShip)
                {
                    //if (ship.GetXPos == bullet
                    //{
                    //    Boom();
                    //}
                }
            }
            //do
            //{
            //    trouver une façon d avoir les bullets
            //} while ((xBullet != xShip) && (yBullet != yShip));   
        }

        protected virtual void Boom(ShipMasterClass ship)
        {
            kaboum?.Invoke(this, new ColDetectEventArgs() { ship = ship });
        }
    }
}
