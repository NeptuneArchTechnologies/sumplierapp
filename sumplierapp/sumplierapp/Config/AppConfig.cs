using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace sumplierapp.Config
{
    public class AppConfig
    {
        // SetCompanyCode
        public void SetCompanyCode(string companyCode)
        {
            Preferences.Set("CompanyCode", companyCode);
        }

        // GetCompanyCode
        public string GetCompanyCode()
        {
            string companyCode = Preferences.Get("CompanyCode", string.Empty);
            return companyCode;
        }

        ///////////////////////////////////////////////////////////////////////////////

        // SetResellerCode
        public void SetResellerCode(string resellerCode)
        {
            Preferences.Set("ResellerCode", resellerCode);
        }

        //GetResellerCode
        public string GetResellerCode()
        {
            string resellerCode = Preferences.Get("ResellerCode", string.Empty);
            return resellerCode;
        }

        ///////////////////////////////////////////////////////////////////////////////

        // SetCustomerCode
        public void SetCustomerCode(string customerCode)
        {
            Preferences.Set("CustomerCode", customerCode);
        }

        //GetCustomerCode
        public string GetCustomerCode()
        {
            string customerCode = Preferences.Get("CustomerCode", string.Empty);
            return customerCode;
        }

        ///////////////////////////////////////////////////////////////////////////////

        // SetCustomerName
        public void SetCustomerName(string customerName)
        {
            Preferences.Set("CustomerName", customerName);
        }

        //GetCustomerName
        public string GetCustomerName()
        {
            string customerName = Preferences.Get("CustomerName", string.Empty);
            return customerName;
        }
    }
}
