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
    //SplashLogo
    [Activity(Theme = "@style/MainTheme", ScreenOrientation = ScreenOrientation.Landscape,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MenuActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static MenuActivity Instance { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Instance = this;

            global::Xamarin.Forms.Forms.Init(this, bundle);
            //ServicePointManager.ServerCertificateValidationCallback += (o, certificate, chain, errors) => true;
            LoadApplication(new App());
        }
    }
}