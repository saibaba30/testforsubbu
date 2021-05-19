using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PoultaryLatam.Droid;
using PoultaryLatam.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(EmailSender))]
namespace PoultaryLatam.Droid
{
    public class EmailSender : IEmailSender
    {
        bool IEmailSender.SendMail(string EmailId, string Subject, string MessageBody)
        {
            var context = MainActivity.Instance;
            if (context == null)
                return false;

            var email = new Intent(Android.Content.Intent.ActionSend);
            email.PutExtra(Android.Content.Intent.ExtraEmail, new string[] { EmailId });
            //email.PutExtra(Android.Content.Intent.ExtraCc, new string[] { "person3@xamarin.com" });
            email.PutExtra(Android.Content.Intent.ExtraSubject, Subject);
            email.PutExtra(Android.Content.Intent.ExtraText, MessageBody);
            email.SetType("message/rfc822");
            context.StartActivity(email);

            return true;
        }
    }
}