﻿using Newtonsoft.Json;
using sumplierapp.BasketManager;
using sumplierapp.Configs;
using sumplierapp.Enum;
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
    public partial class OrderPage : ContentPage
    {
        public OrderPage()
        {
            InitializeComponent();
            AccountCode.Text = Config.Instance.GetCurrentAccountCode().AccountCode.ToString();
            AccountName.Text = Config.Instance.GetCurrentAccountCode().AccountName.ToString();
            GetCategory();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<BasketPage>(this, MessagingCenterEnum.OrderSuccess.ToString(), (sender) =>
            {
                Navigation.PopModalAsync();
                MessagingCenter.Send(this, MessagingCenterEnum.AccountSelected.ToString());
            });
        }
        void GetCategory()
        {
            var Category = Config.Instance.GetMenuCategory(Config.Instance.GetDefaultMenu()).ToList();
            for(int a=0; a<Category.Count; a++)
            {
                Button categoryButton = new Button();
                categoryButton.Text = Category[a].CategoryName;
                categoryButton.StyleId = Category[a].CategoryCode.ToString();
                categoryButton.VerticalOptions = LayoutOptions.Start;
                categoryButton.HorizontalOptions = LayoutOptions.FillAndExpand;
                categoryButton.FontFamily = (Xamarin.Forms.OnPlatform<string>)Xamarin.Forms.Application.Current.Resources["SumplierRegular"];
                categoryButton.CornerRadius = 10;
                categoryButton.BackgroundColor = Color.DarkOrange;
                categoryButton.TextColor = Color.Black;
                categoryButton.TextTransform = TextTransform.None;
                categoryButton.Clicked += CategoryButton_Clicked;
                CategoryLayout.Children.Add(categoryButton);
            }
        }

        private void CategoryButton_Clicked(object sender, EventArgs e)
        {
            CustomerCategory customerCategory = new CustomerCategory();
            customerCategory.CategoryCode = Convert.ToInt64(((Button)sender).StyleId);
            Config.Instance.SetCurrentCategoryCode(customerCategory);
            productFlowListView.FlowItemsSource = Config.Instance.GetCategoryProducts(Config.Instance.GetCurrentCategoryCode());
        }
        public int GenerateTimeBasedId()
        {
            return int.Parse(DateTime.Now.ToString("HHmmssff"));
        }

        private void productFlowListView_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            Config.Instance.SetCurrentBasketId(GenerateTimeBasedId());
            var SelectedProduct = (CustomerProduct)e.Item;
            var ticketOrder = new TicketOrder
            {
                id = Config.Instance.GetCurrentBasketId(),
                ticketId=0,
                barcode = "0",
                productCode = SelectedProduct.ProductCode,
                productName = SelectedProduct.ProductName,
                quantity = 1,
                price = SelectedProduct.Price,
                discountPrice = Convert.ToInt64(0),
                status = 0,
                isChange = false,
                newQuantity = Convert.ToInt64(0),
                newPrice = Convert.ToInt64(0),
                newTotalPrice = Convert.ToInt64(0),
                rowId = GenerateTimeBasedId(),
                companyCode = 1,
                deviceCode =Config.Instance.GetCurrentDevice().deviceCode,
                isDeleted = false
            };

            ticketOrder.totalPrice = ticketOrder.price * ticketOrder.quantity;

            BasketOrderManagers.Instance.AddTicketOrder(ticketOrder);
        }

        private void btnContinue_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BasketPage());
        }

        private void btnBasket_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new BasketPage());
        }

        private void readBarcode_Clicked(object sender, EventArgs e)
        {

        }
    }
}