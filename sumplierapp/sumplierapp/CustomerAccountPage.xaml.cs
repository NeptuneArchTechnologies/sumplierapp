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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<OrderPage>(this, MessagingCenterEnum.AccountSelected.ToString(), (sender) =>
            {
                Navigation.PopModalAsync();
            });
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
                AccountCode = _selectedAccount.AccountCode,
                AccountName = _selectedAccount.AccountName
            };
            Config.Instance.SetCurrentAccountCode(selectedAccount);
            Config.Instance.SetCurrentAccountName(selectedAccount);
            Navigation.PushModalAsync(new OrderPage());
        }
    }
}