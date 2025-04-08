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
		}

        private void btnClose_Clicked(object sender, EventArgs e)
        {
			Navigation.PopModalAsync(true);
        }

        private void btnPayment_Clicked(object sender, EventArgs e)
        {

        }
    }
}