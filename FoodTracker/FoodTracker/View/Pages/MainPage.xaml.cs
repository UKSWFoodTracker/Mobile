﻿using System;
using FoodTracker.ViewModel;
using Xamarin.Forms;

namespace FoodTracker.View
{
	public partial class MainPage : ContentPage
	{
        private MainFeatures _mainFeatures;
	    private Settings _settings;

        public MainPage ()
		{
			InitializeComponent ();
            _settings = new Settings();
		    _mainFeatures = new MainFeatures();
            SetTimerSwitchText();

            lblTime.BindingContext = _settings;
        }

        private async void btnAddMeal_Clicked(object sender, EventArgs e)
        {
            //pass reference to other class page if you want change displayed page
            //example: await Navigation.PushAsync(new MainPage());
            //don't forget type async before method
            var mealPage = new MealPage();
            await Navigation.PushAsync(mealPage);
        }

        private async void btnSettings_Clicked(object sender, EventArgs e)
        {
            // Pass data to other page
            var settingsPage = new SettingsPage(ref _settings, ref _mainFeatures);
            await Navigation.PushAsync(settingsPage);
        }

	    private void BtnTimerSwitch_OnClicked(object sender, EventArgs e)
	    {
	        if (!_settings.TimerIsActive)
	        {
                // Start notifications
	            int totalMiliseconds = (int)_settings.IntervalValueTimeSpan.TotalMilliseconds;
	            _mainFeatures.NotifyManager.StartNotification(totalMiliseconds);
            }
	        else
	        {
                // Stop notifications
                _mainFeatures.NotifyManager.StopNotification();
	        }
            SetTimerSwitchText();
        }

	    private void SetTimerSwitchText()
	    {
	        if (!_settings.TimerIsActive)
	        {
	            btnTimerSwitch.Text = "Off";
            }
	        else
	        {
	            btnTimerSwitch.Text = "On";
            }
	    }
	}
}
