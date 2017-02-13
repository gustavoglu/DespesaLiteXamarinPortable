using Despesa.Lite.Xamarin.Portable.Paginas.Loguin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Despesa.Lite.Xamarin.Portable
{
    public class App : Application
    {
        public static NavigationPage nav_request = new NavigationPage(new P_Loguin());

        public App()
        {
            // The root page of your application
            MainPage = nav_request;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
