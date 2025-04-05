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
	public partial class DashboardPage : ContentPage
	{
		public DashboardPage (string userName)
		{
			InitializeComponent ();
		}
	}
}