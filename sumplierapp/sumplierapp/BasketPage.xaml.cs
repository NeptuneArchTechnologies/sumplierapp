using sumplierapp.BasketManager;
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
	public partial class BasketPage : ContentPage
	{
		public BasketPage ()
		{
			InitializeComponent ();
            //GetBasketOrder(Config.Instance.GetCurrentBasketId());
            BindingContext = BasketOrderManagers.Instance;
        }

        //void GetBasketOrder(int basketId)
        //{
        //    basketOrderFlowListView.FlowItemsSource = BasketOrderManagers.Instance.GetByTicketId(basketId);
        //}

        private void btnClose_Clicked(object sender, EventArgs e)
        {
			Navigation.PopModalAsync(true);
        }

        private void btnPayment_Clicked(object sender, EventArgs e)
        {

        }

        private void basketOrderFlowListView_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void allClear_Clicked(object sender, EventArgs e)
        {
            BasketOrderManagers.Instance.ClearAll();
            BindingContext = BasketOrderManagers.Instance;
        }
    }
}