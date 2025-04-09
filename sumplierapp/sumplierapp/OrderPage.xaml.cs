using sumplierapp.Configs;
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
            //AccountCode.Text = Config.Instance.GetCurrentAccountCode().AccountCode.ToString();
            //AccountName.Text = Config.Instance.GetCurrentAccountCode().AccountName.ToString();
            //GetCategory();
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

        private void productFlowListView_FlowItemTapped(object sender, ItemTappedEventArgs e)
        {

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