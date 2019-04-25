
using System;
using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamd.ImageCarousel.Forms.Plugin.Droid;

namespace Tourisum.Droid
{
    [Activity(Label = "Tourisum", Icon = "@drawable/index18", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            ImageCarouselRenderer.Init();

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            UserDialogs.Init(() => this);
            LoadApplication(new App());
        }

        public override void OnBackPressed()
        {
            OnBackPressedMethod();
        }

        private bool OnBackPressedMethod()
        {
            return false;
        }
    }
}