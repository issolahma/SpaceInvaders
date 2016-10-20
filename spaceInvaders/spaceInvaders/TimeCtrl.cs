using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace spaceInvaders
{
    public class TimeCtrl
    {
        private int interval = 0;
        private Timer timer = new Timer();
        public EventHandler timeUp;
        
        public TimeCtrl(int interval)
        {
            this.interval = interval;
            InitTimer();
        }

        private void InitTimer()
        {
            timer.Interval = interval;
            timer.Elapsed += new ElapsedEventHandler(Event);
            timer.Start();
        }

        public void Event(object source, ElapsedEventArgs e)
        {
            timeUp?.Invoke(this, new EventArgs());
        }
    }
}
