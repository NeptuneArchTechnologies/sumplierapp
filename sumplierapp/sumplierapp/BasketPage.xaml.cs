using Newtonsoft.Json;
using sumplierapp.Api;
using sumplierapp.BasketManager;
using sumplierapp.Configs;
using sumplierapp.Enum;
using sumplierapp.LocalDatabase;
using sumplierapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace sumplierapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasketPage : ContentPage
    {
        
        public static decimal _subTotal, _taxTotal, _discountTotal, _generalTotal;
        public BasketPage()
        {
            InitializeComponent();
            BindingContext = BasketOrderManagers.Instance;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            calculationTicket();

            MessagingCenter.Subscribe<PaymentPage>(this, MessagingCenterEnum.PaymentSuccess.ToString(), (sender) =>
            {
                Navigation.PopModalAsync();
                MessagingCenter.Send(this, MessagingCenterEnum.OrderSuccess.ToString());
            });
        }
        private void btnClose_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync(true);
        }

        private void OnEditSwipeItemInvoked(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var selectedItem = swipeItem?.CommandParameter as TicketOrder;

            if (selectedItem != null)
            {
                DisplayAlert("Bilgi", selectedItem.id.ToString(), "Tamam");
            }
        }

        private void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var selectedItem = swipeItem?.CommandParameter as TicketOrder;

            if (selectedItem != null)
            {
                BasketOrderManagers.Instance.DeleteTicketOrderRowId(selectedItem.rowId);
                BindingContext = BasketOrderManagers.Instance;
            }
        }

        private void btnPayment_Clicked(object sender, EventArgs e)
        {
            Ticket ticket = new Ticket();
            ticket.id = 0;
            ticket.ticketCode = 0;
            ticket.companyCode = Config.Instance.GetCurrentCustomer().CompanyCode;
            ticket.accountCode = Convert.ToInt64(Config.Instance.GetCurrentAccountCode().AccountCode);
            ticket.accountName = Config.Instance.GetCurrentAccountName().AccountName;
            ticket.resellerCode = Config.Instance.GetCurrentCustomer().ResellerCode;
            ticket.customerCode = Config.Instance.GetCurrentCustomer().CustomerCode;
            ticket.userCode = Config.Instance.GetCurrentUser().UserCode;
            ticket.createDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
            ticket.modifiedDateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff"));
            ticket.total = Convert.ToInt64(_subTotal);
            ticket.discountTotal = Convert.ToInt64(_discountTotal);
            ticket.taxTotal = Convert.ToInt64(0);
            ticket.generalTotal = Convert.ToInt64(_generalTotal);
            ticket.paymentType = "Nakit";
            ticket.description = "Yeni oluşturulan fiş";
            ticket.status = 1;
            ticket.deviceCode = Config.Instance.GetCurrentDevice().deviceCode;
            ticket.statusName = "Açık";
            ticket.paymentStatus = 0;
            ticket.isDeleted = false;
            ticket.ticketOrders = BasketOrderManagers.Instance.GetTicketOrder();

            string json = JsonConvert.SerializeObject(ticket, Formatting.None);
            Preferences.Set("CurrentTicket",json);
            Navigation.PushModalAsync(new PaymentPage());
        }

        private void basketOrderFlowListView_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private void allClear_Clicked(object sender, EventArgs e)
        {
            BasketOrderManagers.Instance.ClearAll();
            BindingContext = BasketOrderManagers.Instance;
        }
        private void calculationTicket()
        {
            _subTotal = 0;
            _discountTotal = 0;
            _generalTotal = 0;
            List<TicketOrder> ticketOrderList = BasketOrderManagers.Instance.BasketOrders.ToList();
            for (int a = 0; a < ticketOrderList.Count; a++)
            {
                _subTotal += ticketOrderList[a].totalPrice;
                _discountTotal += ticketOrderList[a].discountPrice;
                _generalTotal += ticketOrderList[a].totalPrice;
            }
            subTotal.Text = _subTotal.ToString("0.00");
            discountTotal.Text = _discountTotal.ToString("0.00");
            //taxTotal.Text = _subTotal.ToString("0.00");
            generalTotal.Text = _generalTotal.ToString("0.00");
        }
    }
}