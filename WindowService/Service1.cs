using WindowService.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowService
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer = null;
        Helper api = new Helper();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer
            {
                Interval = 5000
            };
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Tick);
            timer.Enabled = true;
            Helper.WriteLog("Collectex Service is Started");

        }

        private void Timer_Tick(object sender, ElapsedEventArgs e)
        {
            Helper.WriteLog("Ticker Event Executed");
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
            Helper.WriteLog("Collectex Service is Stoped");
        }
    }
}
