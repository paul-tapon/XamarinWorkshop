using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            System.Net.ServicePointManager.ServerCertificateValidationCallback =ServerCertificateValidationCallback;

        }

        private bool ServerCertificateValidationCallback(object sender,
                                                                  X509Certificate certificate,
                                                                  X509Chain chain,
                                                                  SslPolicyErrors sslPolicyErrors)
        {
            // Very simple certificate hash check
            return true;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
