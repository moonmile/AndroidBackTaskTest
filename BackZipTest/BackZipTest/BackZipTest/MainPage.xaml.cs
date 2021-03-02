using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BackZipTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Appearing += mainPage_Appearing;
        }

        private void mainPage_Appearing(object sender, EventArgs e)
        {
            _vm = new MainViewModel();
            this.BindingContext = _vm;
        }
        MainViewModel _vm;

        private void clickStart(object sender, EventArgs e)
        {
            _vm.Start();
        }

        private void clickStop(object sender, EventArgs e)
        {
            _vm.Stop();
        }
    }
}
