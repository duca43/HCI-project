using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MyProject.Other
{
    public class Ticker : INotifyPropertyChanged
    {
        public Ticker()
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Tick;
            timer.Start();
        }

        public DateTime Now
        {
            get { return DateTime.Now; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void Tick(object sender, ElapsedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Now"));
        }

    }
}
