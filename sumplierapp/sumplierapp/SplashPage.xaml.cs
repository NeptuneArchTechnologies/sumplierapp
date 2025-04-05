using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sumplierapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
            InitConfig(5);
        }

        private void InitConfig(double time)
        {
            Device.StartTimer(TimeSpan.FromSeconds(time), () =>
            {
                Navigation.PushModalAsync(new DashboardPage("Ahmet Serdar KARABULUT"));
                return false;
            });
        }
    }
}