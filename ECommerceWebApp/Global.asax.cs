using System;
using System.Web;
using System.Diagnostics; //logging

namespace ECommerceWebApp
{
    public class Global : HttpApplication //load count 
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Debug.WriteLine("E-Commerce App Started: Seller Account Service Initialized");
        }
    }
}