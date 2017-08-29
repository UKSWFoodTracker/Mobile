﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace FoodTracker.PlatformServices.Notifications.Options
{
    class TimerOption : Option
    {
        public TimerOption(string name) : base(name)
        {
            startNotifyTime = StartNotifyTimer;

            zeroTime = DateTime.Parse("01.01.2000");
        }
        /// <summary>
        /// Time which indicates the beginning of an interval. 
        /// It means time when we start count down timer. 
        /// </summary>
        private TimeSpan startNotifyTime;
        /// <summary>
        /// According to that time we substract and add times
        /// </summary>
        private DateTime zeroTime;
        /// <summary>
        /// Time left to the end of next interval. It should be binded with a page's controls
        /// </summary>
        public string HowMuchTimeLeft
        {
            get
            {
                TimeSpan time = startNotifyTime - (DateTime.Now - zeroTime);
                return String.Format("{0:hh\\:mm\\:ss}", time);
            }
        }
        /// <summary>
        /// Property for startNotifyTime and it saves value to MyProperties class as well. 
        /// <see cref="TimerOption.startNotifyTime"/> 
        /// </summary>
        private TimeSpan StartNotifyTimer
        {
            get
            {
                var app = Application.Current as App;
                return app.myProperties.StartNotifyTime;
            }
            set
            {
                var app = Application.Current as App;
                app.myProperties.StartNotifyTime = value;
                startNotifyTime = value;
            }
        }
        public void SetTimer(TimeSpan intervalValue)
        {
            //Forecasting when timer goes off
            startNotifyTime = intervalValue + (DateTime.Now - zeroTime);
            StartNotifyTimer = startNotifyTime;
        }
    }
}