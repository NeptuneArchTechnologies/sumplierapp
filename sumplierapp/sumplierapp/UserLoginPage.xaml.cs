using Newtonsoft.Json;
using sumplierapp.Api;
using sumplierapp.Config;
using sumplierapp.Enum;
using sumplierapp.Model;
﻿using sumplierapp.Api;
using sumplierapp.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using sumplierapp.LocalDatabase;

namespace sumplierapp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserLoginPage : ContentPage
    {
        public UserLoginPage()//Bir önceki sayfadan gelen veri buraya geliyor
        {
            InitializeComponent();
            customerName = appConfig.GetCustomerName();//UserLoginde ilgili alana setlenebilir

            LoginTypeEnum.App.ToString(); // Yaparsan string olan adı gelir
            int type = (int)LoginTypeEnum.App; // Yaparsan int değeri gelir

            

        public UserLoginPage()//Bir önceki sayfadan gelen veri buraya geliyor
        {
            InitializeComponent();

        }

        private void btnUserLogin_Clicked(object sender, EventArgs e)
        {

            // Get the mail and password
            string email = userEmail.Text;
            string password = userPassword.Text;

            var apiService = new ApiService();

            // Inline ApiCallBacks
            apiService.GetUserLogin(email, password,
                user => {

                    if (user != null)
                    {

                        Console.WriteLine($"Giriş başarılı {user}");
                        DataStorage.Instance.SaveModel(DbKey.User.Name(), user);
                        Navigation.PushModalAsync(new SplashPage());
                    }

                },
                errorMessage => {
                    Console.WriteLine($"Giriş başarısız: {errorMessage}");
                });
        }

        
    }
}