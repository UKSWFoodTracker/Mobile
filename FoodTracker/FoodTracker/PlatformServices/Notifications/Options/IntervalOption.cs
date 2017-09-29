﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.PlatformServices.Notifications.Options
{
    public class IntervalOption : Option<TimeSpan>
    {
        public IntervalOption() : base("Interval")
        {
            GetFromMyProperties();
        }

        protected sealed override TimeSpan GetFromMyProperties()
        {
            var app = Application.Current as App;
            return app.myProperties.IntervalTimeSpan;
        }

        protected override void SaveToMyProperties(TimeSpan value)
        {
            var app = Application.Current as App;
            app.myProperties.IntervalTimeSpan = value;
        }
    }
}
