using Newtonsoft.Json;
using sumplierapp.Api;
using sumplierapp.Configs;
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
        }

        private void btnUserLogin_Clicked(object sender, EventArgs e)
        {

            // Get the mail and password
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

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