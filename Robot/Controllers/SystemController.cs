﻿using Microsoft.AspNet.SignalR;
using Robot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Robot.Controllers
{
    public class SystemController : IRegisteredObject, ISystemController
    {
        protected static ISystemController _instance = null;

        private Timer _taskTimer;
        private IHubContext _hub;

        private DateTime _startTime;

        public string Url { get; set; }

        public SystemController()
        {
            Console.WriteLine("**** 1 ****");
            HostingEnvironment.RegisterObject(this);
            Console.WriteLine("**** 2 ****");
            _taskTimer = new Timer(OnTimerElapsed, null,
                TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(.1));
            Console.WriteLine("**** 3 ****");
            _startTime = DateTime.Now;
            Console.WriteLine("**** 4 ****");
        }

        public static ISystemController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SystemController();
                }
                return _instance;
            }
        }

        public void SetHub<T>()
            where T : Hub
        {
            _hub = GlobalHost.ConnectionManager.GetHubContext<T>();
        }

        private void OnTimerElapsed(object sender)
        {
            this.OnTimer();
        }

        protected virtual void OnTimer()
        {
        }

        public virtual void ReceiveMessage(IInputModel message)
        {
        }

        protected void BroadcastMessage(IDisplayModel message)
        {
            if(_hub.Clients != null)
                _hub.Clients.All.broadcastMessage(message);
        }

        public void Stop(bool immediate)
        {
            _taskTimer.Dispose();

            HostingEnvironment.UnregisterObject(this);
        }
    }
}
