using sumplierapp.Configs;
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
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            AccountCode.Text = Config.Instance.GetCurrentAccountCode().AccountCode.ToString();
            AccountName.Text = Config.Instance.GetCurrentAccountCode().AccountName.ToString();
        }
    }
}