using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace BackZipTest.Droid
{
    [Activity(Label = "BackZipTest", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        SampleReceiver receiver;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            // 強引だがコンテキストを保存しておく
            MainActivity.Context = this;
            receiver = new SampleReceiver();

        }

        protected override void OnResume()
        {
            base.OnResume();
            // 起動時にレジストされる
            // ※この部分がないと、START ボタンを押しても Intent が送られない
            // cocoa の MainActivity.cs に RegisterReceiver がないのが問題では？
            RegisterReceiver(receiver, 
               new Android.Content.IntentFilter("net.moonmile.download"));
            
        }
        protected override void OnPause()
        {
            UnregisterReceiver(receiver);
            base.OnPause();
        }

        public static MainActivity Context { get; set; }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}