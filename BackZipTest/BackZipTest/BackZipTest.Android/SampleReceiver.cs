using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(BackZipTest.Droid.BackTask))]
namespace BackZipTest.Droid
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { "net.moonmile.download" })]
    [Preserve]
    public class SampleReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var action = intent.Action;
            if ( action == "net.moonmile.download")
            {
                // JobIntent へ
                SampleIntentService.EnqueueWork( context, intent);
            }
        }
    }

    [Service(
        Permission = "android.permission.BIND_JOB_SERVICE")]
    [Preserve]
    public class SampleIntentService : JobIntentService
    {
        public static void EnqueueWork(Context context, Intent work)
            => EnqueueWork(context, 
                Java.Lang.Class.FromType(typeof(SampleIntentService)), 
                0, work);

        protected override void OnHandleWork(Intent p0)
        {
            // 共通処理へコールバック
            var msg = "call " + DateTime.Now.ToString("hh:mm:ss");
            BackTask._me.GoCallback(msg);
        }
    }


    public class BackTask : IBackTask
    {
        public static BackTask _me;

        public void Kick()
        {
            BackTask._me = this;

            var intent = new Intent("net.moonmile.download");
            MainActivity.Context.SendBroadcast(intent);
        }

        public event Action<string> Callback;
        public void GoCallback(string message)
        {
            this.Callback?.Invoke( message);
        }
    }
}