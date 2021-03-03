using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RequiresDeviceIdleTest
{
    class MainViewModel : ObservableObject
    {
        private DateTime _Now = DateTime.Now;
        private int _Count = 0;
        private string _Message = "";

        public DateTime Now
        {
            get => _Now;
            set => SetProperty(ref _Now, value, nameof(Now));
        }
        public int Count
        {
            get => _Count;
            set => SetProperty(ref _Count, value, nameof(Count));
        }
        public string Message
        {
            get => _Message;
            set => SetProperty(ref _Message, value, nameof(Message));
        }

        IBackTask _backtask;

        public MainViewModel()
        {
            _backtask = DependencyService.Get<IBackTask>();
            _backtask.Callback += _backtask_Callback;
        }

        /// <summary>
        /// コールバックメッセージを表示
        /// </summary>
        /// <param name="msg"></param>
        private void _backtask_Callback(string msg)
        {
            this.Count += 1;
            this.Now = DateTime.Now;
            this.Message = msg;
        }

        /// <summary>
        /// テストパターンの設定
        /// </summary>
        public void GoTest0()
        {
            this.Message = $"start 0 " + DateTime.Now.ToString("HH:mm:ss");
            _backtask.Kick(0);
        }
        public void GoTest1()
        {
            this.Message = $"start 1 " + DateTime.Now.ToString("HH:mm:ss");
            _backtask.Kick(1);
        }
        public void GoTest2()
        {
            this.Message = $"start 2 " + DateTime.Now.ToString("HH:mm:ss");
            _backtask.Kick(2);
        }
        public void GoTest3()
        {
            this.Message = $"start 3 " + DateTime.Now.ToString("HH:mm:ss");
            _backtask.Kick(3);
        }
        public void GoTest4()
        {
            this.Message = $"start 4 " + DateTime.Now.ToString("HH:mm:ss");
            _backtask.Kick(4);
        }
        public void GoTest5()
        {
            this.Message = $"start 5 " + DateTime.Now.ToString("HH:mm:ss");
            _backtask.Kick(5);
        }
        public void GoTest6()
        {
            this.Message = $"start 6 " + DateTime.Now.ToString("HH:mm:ss");
            _backtask.Kick(6);
        }

    }
    public interface IBackTask
    {
        void Kick(int num);
        void GoCallback(string message);
        event Action<string> Callback;
    }

}
