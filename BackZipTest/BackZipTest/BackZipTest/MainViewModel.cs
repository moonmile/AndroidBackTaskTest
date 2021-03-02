using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BackZipTest
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

        private IBackTask _backtask;
        public MainViewModel()
        {
            _backtask = DependencyService.Get<IBackTask>();
            _backtask.Callback += _backtask_Callback;
        }

        private void _backtask_Callback(string msg)
        {
            this.Message = msg;
            this.Now = DateTime.Now;
        }

        /// <summary>
        /// バックグランドスレッドを開始
        /// </summary>
        public void Start()
        {
            this.Now = DateTime.Now;
            _backtask.Kick();
        }

        /// <summary>
        /// バックグランドスレッドを停止
        /// </summary>
        public void Stop()
        {

        }
    }

    public interface IBackTask
    {
        void Kick();
        void GoCallback(string message);
        event Action<string> Callback;
    }
}
