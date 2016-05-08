using Robot.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Controllers
{
    public class TestController : SystemController
    {
        private TimeSpan _startTime;
        private double _f;
        private string _url;

        public TestController()
        {
            _url = ConfigurationManager.AppSettings["baseUrl"];
            ResetTimer();
            _f = 0;
        }

        public static new ISystemController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TestController();
                }
                return _instance;
            }
        }

        protected override void OnTimer()
        {
            DateTime now = DateTime.Now;
            TimeSpan tsNow = new TimeSpan(now.Hour, now.Minute, now.Second);

            _f += 0.01;

            DisplayModel model = new DisplayModel()
            {
                EventName = "test-display-update",
                
                Date = DateTime.Now,

                Time = new TimeModel
                {
                    Hour = (tsNow - _startTime).Hours,
                    Minute = (tsNow - _startTime).Minutes,
                    Second = (tsNow - _startTime).Seconds,
                },

                Url = _url,
            };
            this.BroadcastMessage(model);

        }
        
        public override void ReceiveMessage(IInputModel model)
        {
            InputModel m = (InputModel)model;

            if (m.EventName == "reset")
                ResetTimer();
        }

        private void ResetTimer()
        {
            DateTime now = DateTime.Now;
            _startTime = new TimeSpan(now.Hour, now.Minute, now.Second);
        }
    }
}
