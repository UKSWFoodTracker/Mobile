﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using FoodTracker.PlatformServices.Notifications.AlarmClock;
using FoodTracker.ViewModel;

namespace FoodTracker.Droid
{
	[Activity (Label = "FoodTracker", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new FoodTracker.App ());

            AlarmClockManager.Main = this;
		}
    }
}

