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
        public App()
        {
            // The root page of your application
            MainPage = new P_Loguin();
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
