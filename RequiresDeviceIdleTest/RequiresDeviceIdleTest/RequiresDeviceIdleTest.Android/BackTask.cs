using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Android.Support.V7.App;
using Java.Util.Concurrent;
using AndroidX.Work;

[assembly: Xamarin.Forms.Dependency(typeof(RequiresDeviceIdleTest.Droid.BackTask))]
namespace RequiresDeviceIdleTest.Droid
{
    class BackTask : IBackTask
    {
        public event Action<string> Callback;


        public void GoCallback(string message)
        {
            this.Callback?.Invoke(message);
        }

        public static BackTask _me;
        public int num;         // テスト番号


        public void Kick( int num )
        {
            _me = this;
            switch ( num )
            {
                case 0: WorkTest0(); break;
                case 1: WorkTest1(); break;
                case 2: WorkTest2(); break;
                case 3: WorkTest3(); break;
                case 4: WorkTest4(); break;
                case 5: WorkTest5(); break;
                case 6: WorkTest6(); break;
            }
        }

        static int INTERVAL = 16;


        // Doesn't work
        private void WorkTest0()
        {
            this.num = 0;
            var workManager = WorkManager.GetInstance(Xamarin.Essentials.Platform.AppContext);

            var workRequestBuilder = new PeriodicWorkRequest.Builder(typeof(SampleWorker), TimeSpan.FromMinutes(INTERVAL))
                .SetConstraints(new Constraints.Builder()
                //.SetRequiresBatteryNotLow(true)
                .SetRequiresDeviceIdle(true)
                //.SetRequiredNetworkType(NetworkType.Connected)
                .Build());

            var workRequest = workRequestBuilder.Build();
            workManager.EnqueueUniquePeriodicWork(
                "exposurenotificaiton",
                ExistingPeriodicWorkPolicy.Replace,
                workRequest);
        }

        // Doesn't work
        private void WorkTest1()
        {
            this.num = 1;
            var workManager = WorkManager.GetInstance(Xamarin.Essentials.Platform.AppContext);

            var workRequestBuilder = new PeriodicWorkRequest.Builder(typeof(SampleWorker), TimeSpan.FromMinutes(INTERVAL))
                .SetConstraints(new Constraints.Builder()
                .SetRequiresBatteryNotLow(true)
                .SetRequiresDeviceIdle(true)
                //.SetRequiredNetworkType(NetworkType.Connected)
                .Build());

            var workRequest = workRequestBuilder.Build();
            workManager.EnqueueUniquePeriodicWork(
                "exposurenotificaiton",
                ExistingPeriodicWorkPolicy.Replace,
                workRequest);
        }

        // Works fine
        private void WorkTest2()
        {
            this.num = 2;
            var workManager = WorkManager.GetInstance(Xamarin.Essentials.Platform.AppContext);

            var workRequestBuilder = new PeriodicWorkRequest.Builder(typeof(SampleWorker), TimeSpan.FromMinutes(INTERVAL))
                .SetConstraints(new Constraints.Builder()
                .SetRequiresBatteryNotLow(true)
                //.SetRequiresDeviceIdle(true)
                .SetRequiredNetworkType(NetworkType.Connected)
                .Build());

            var workRequest = workRequestBuilder.Build();
            workManager.EnqueueUniquePeriodicWork(
                "exposurenotificaiton",
                ExistingPeriodicWorkPolicy.Replace,
                workRequest);
        }

        // Doesn't work
        private void WorkTest3()
        {
            this.num = 3;
            var workManager = WorkManager.GetInstance(Xamarin.Essentials.Platform.AppContext);

            var workRequestBuilder = new PeriodicWorkRequest.Builder(typeof(SampleWorker), TimeSpan.FromMinutes(INTERVAL))
                .SetConstraints(new Constraints.Builder()
                .SetRequiresBatteryNotLow(true)
                .SetRequiresDeviceIdle(true)
                .SetRequiredNetworkType(NetworkType.Connected)
                .Build());

            var workRequest = workRequestBuilder.Build();
            workManager.EnqueueUniquePeriodicWork(
                "exposurenotificaiton",
                ExistingPeriodicWorkPolicy.Replace,
                workRequest);
        }

        // Works fine
        private void WorkTest4()
        {
            this.num = 4;
            var workManager = WorkManager.GetInstance(Xamarin.Essentials.Platform.AppContext);

            var workRequestBuilder = new PeriodicWorkRequest.Builder(typeof(SampleWorker), TimeSpan.FromMinutes(INTERVAL));

            var workRequest = workRequestBuilder.Build();
            workManager.EnqueueUniquePeriodicWork(
                "exposurenotificaiton",
                ExistingPeriodicWorkPolicy.Replace,
                workRequest);
        }

        // Works fine
        private void WorkTest5()
        {
            this.num = 5;
            var workManager = WorkManager.GetInstance(Xamarin.Essentials.Platform.AppContext);

            var workRequestBuilder = new PeriodicWorkRequest.Builder(typeof(SampleWorker), INTERVAL, TimeUnit.Minutes);

            var workRequest = workRequestBuilder.Build();
            workManager.EnqueueUniquePeriodicWork(
                "exposurenotificaiton",
                ExistingPeriodicWorkPolicy.Replace,
                workRequest);
        }

        // Works fine
        private void WorkTest6()
        {
            this.num = 6;
            var workManager = WorkManager.GetInstance(Xamarin.Essentials.Platform.AppContext);

            var workRequestBuilder = PeriodicWorkRequest.Builder.From<SampleWorker>(INTERVAL, TimeUnit.Minutes);

            var workRequest = workRequestBuilder.Build();
            workManager.EnqueueUniquePeriodicWork(
                "exposurenotificaiton",
                ExistingPeriodicWorkPolicy.Replace,
                workRequest);
        }
    }

    /// <summary>
    /// 呼び出されるワーカークラス
    /// </summary>
    public class SampleWorker : Worker
    {
        public SampleWorker(Context context, WorkerParameters workerParameters) : base(context, workerParameters)
        {

        }
        public override Result DoWork()
        {
            Android.Util.Log.Debug("SampleWorker", "Work");
            BackTask._me?.GoCallback($"call {BackTask._me.num} " + DateTime.Now.ToString("HH:mm:ss"));
            return Result.InvokeSuccess();
        }
    }
}