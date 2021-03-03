using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RequiresDeviceIdleTest
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
        private void clickStartTest0(object sender, EventArgs e)
        {

        }
        private void clickStartTest1(object sender, EventArgs e)
        {

        }
        private void clickStartTest2(object sender, EventArgs e)
        {

        }
        private void clickStartTest3(object sender, EventArgs e)
        {

        }
        private void clickStartTest4(object sender, EventArgs e)
        {

        }
        private void clickStartTest5(object sender, EventArgs e)
        {

        }
        private void clickStartTest6(object sender, EventArgs e)
        {

        }

        private void clickKick(object sender, EventArgs e)
        {

        }
    }
}
