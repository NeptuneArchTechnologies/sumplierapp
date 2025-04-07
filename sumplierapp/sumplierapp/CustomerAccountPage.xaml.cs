using sumplierapp.Configs;
using sumplierapp.Enum;
using sumplierapp.LocalDatabase;
using sumplierapp.Model;
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
    public partial class CustomerAccountPage : ContentPage
    {
        public CustomerAccountPage()
        {
            InitializeComponent();
            GetCustomerAccount();
        }

        void GetCustomerAccount()
        {
            customerAccountFlowListView.FlowItemsSource = Config.Instance.GetAllAccounts();
        }
        private void btnClose_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }

        private void customerAccountFlowListView_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            var _selectedAccount = (CustomerAccount)e.Item;
            var selectedAccount = new CustomerAccount
            {
                AccountCode = _selectedAccount.AccountCode
            };
            Config.Instance.SetCurrentAccountCode(selectedAccount);
            Navigation.PushModalAsync(new OrderPage());
        }
    }
}