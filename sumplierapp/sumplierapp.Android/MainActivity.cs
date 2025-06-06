﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Views;

namespace sumplierapp.Droid
{
    [Activity(Label = "Sumplier", Icon = "@drawable/sumplierapp_icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Window.AddFlags(Android.Views.WindowManagerFlags.Fullscreen);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnResume()
        {
            base.OnResume();
            KeepSystemUIHidden();
        }

        [Obsolete]
        private void HideSystemUI()
        {
            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(
                SystemUiFlags.LayoutStable | 
                SystemUiFlags.LayoutHideNavigation | 
                SystemUiFlags.LayoutFullscreen | 
                SystemUiFlags.HideNavigation | 
                SystemUiFlags.Fullscreen | 
                SystemUiFlags.ImmersiveSticky
            );
        }
        private void KeepSystemUIHidden()
        {
            Handler handler = new Handler();
            handler.PostDelayed(() => { HideSystemUI(); KeepSystemUIHidden(); }, 100);
        }
    }
}