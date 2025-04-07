using sumplierapp.Threads;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sumplierapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        private readonly LocationThread locationThread;

        public DashboardPage()
        {
            InitializeComponent();
            locationThread = new LocationThread();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await locationThread.CheckAndStartLocationService();
        }
    }
}
