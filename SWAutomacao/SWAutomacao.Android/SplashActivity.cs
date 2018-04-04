using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SWAutomacao.Droid
{
    [Activity(Icon = "@drawable/logo", ScreenOrientation = ScreenOrientation.Landscape, 
        Theme = "@style/SplashTheme", MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            StartActivity(typeof(MenuActivity));
            // Create your application here
            Finish();
            OverridePendingTransition(0, 0);
        }
    }
}