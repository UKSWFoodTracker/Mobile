﻿using System;
using System.Collections.Generic;
using System.Text;
using FoodTracker.PlatformServices.Notifications.Options;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace FoodTracker.Model
{
    //Main class to manage options
    public class Settings
    {
        public Settings()
        {
            //Loading pop-up interval from saved properties
            interval = new IntervalOption("Pop-ups interval", getInterval());
            notify = new NotifyOption("Notification", getNotifyState());
            vibrate = new VibrateOption("Vibrate", getVibrateState());
            // TODO: ADDING NEW OPTION: creating object
        }
        // Interval option properties
        private IntervalOption interval;
        public string IntervalName
        {
            get => interval.Name;
        }
        public string IntervalValue
        {
            get => String.Format("{0:hh\\:mm\\:ss}", interval.TimePeriod);
            set
            {
                TimeSpan timeValue = TimeSpan.Parse(value);
                interval.TimePeriod = timeValue;
                var app = Application.Current as App;
                app.myProperties.IntervalTimeSpan = timeValue;
                OnPropertyChanged();
            }
        }
        private NotifyOption notify;
        public string NotifyName
        {
            get => notify.Name;
        }
        public bool NotifyValue
        {
            get => notify.OnState;
            set
            {
                notify.OnState = value;
                // Saving in app properties
                var app = Application.Current as App;
                app.myProperties.NotifyState = value;
                // Cancel notification request
                OnStopRequest();

                OnPropertyChanged();
            }
        }
        private VibrateOption vibrate;
        public string VibrateName
        {
            get => vibrate.Name;
        }
        public bool VibrateValue
        {
            get => vibrate.OnState;
            set
            {
                vibrate.OnState = value;
                var app = Application.Current as App;
                app.myProperties.VibrateState = value;
                OnPropertyChanged();
            }
        }
        // TODO: ADDING NEW OPTION: properties

        private TimeSpan getInterval()
        {
            var app = Application.Current as App;
            return app.myProperties.IntervalTimeSpan;
        }

        private bool getVibrateState()
        {
            var app = Application.Current as App;
            return app.myProperties.VibrateState;
        }

        private bool getNotifyState()
        {
            var app = Application.Current as App;
            return app.myProperties.NotifyState;
        }
        //TODO: ADDING NEW OPTION: return options' value from application properties

        /// <summary>
        /// Update specified value in form
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        /// <summary>
        /// Request to stop notifications
        /// </summary>
        public event StopRequestHandler StopRequestEvent;
        public delegate void StopRequestHandler();
        private void OnStopRequest()
        {
            StopRequestHandler stopRequest = StopRequestEvent;
            if (stopRequest == null)
            {
                return;
            }
            stopRequest();
        }
    }
}
