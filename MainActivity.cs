using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Platform;
using Rg.Plugins.Popup.Pages;
using Android.Content;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace PoultaryLatam.Droid
{
    [Activity(Label = "Pipasa", Icon = "@drawable/icon", Theme = "@style/MainTheme", 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, 
        ScreenOrientation = ScreenOrientation.Portrait, LaunchMode = LaunchMode.SingleTask)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        bool doubleBackToExitPressedOnce = false;

        internal static MainActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            Instance = this;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            CachedImageRenderer.Init(true);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            App.Instance.ScreenWidth = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);
            LoadApplication(new App());
            Window.SetStatusBarColor(Android.Graphics.Color.Rgb(150, 148, 148)); //here
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);

        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            if (intent != null && LoginProvider.Current != null)
            {
                LoginProvider.Current.NotifyOfCallback(intent);
            }
        }

        public override void OnBackPressed()
        {
            if (!App.Instance.DoBack)
            {
                base.OnBackPressed();
            }
            else
            {
                if (doubleBackToExitPressedOnce)
                {
                    base.OnBackPressed();
                    Java.Lang.JavaSystem.Exit(0);
                    return;
                }

                this.doubleBackToExitPressedOnce = true;
                Toast.MakeText(this, "Press back again to exit.", ToastLength.Short).Show();

                new Handler().PostDelayed(() =>
                {
                    doubleBackToExitPressedOnce = false;
                }, 2000);
            }
        }

    }
}

