using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PoultaryLatam.Droid;
using PoultaryLatam.Interfaces;
using PoultaryLatam.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(MessageAndroid))]
namespace PoultaryLatam.Droid
{
    public class MessageAndroid : IMessage
    {

        public void LongAlert(string message)
        {
            Toast toast = Toast.MakeText(Application.Context, message, ToastLength.Long);
            toast = FormatToast(toast);
            toast.Show();
        }

        public void ShortAlert(string message)
        {
            Toast toast = Toast.MakeText(Application.Context, message, ToastLength.Short);
            toast = FormatToast(toast);
            toast.Show();
        }

        private Toast FormatToast(Toast toast) {
            toast.SetGravity(GravityFlags.Center, 0, 0);
            View toastView = toast.View;

            GradientDrawable toastBackground = new Android.Graphics.Drawables.GradientDrawable();
            toastBackground.SetColor(Android.Graphics.Color.ParseColor(Constants.ToastMessageBackgroundColor));
            toastBackground.SetCornerRadius((float)35.0);
            toastView.SetBackgroundDrawable(toastBackground);

            TextView toastMessage = (TextView) toastView.FindViewById(Android.Resource.Id.Message);
            toastMessage.SetTextColor(Android.Graphics.Color.ParseColor(Constants.ToastMessageTextColor));

            return toast;
        
        }
    }
}
