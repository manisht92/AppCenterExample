using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppCenterExample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CustomBehaviorPage();

            if (!AppCenter.Configured)
            {
                Push.PushNotificationReceived += (sender, e) =>
                {
                    // Add the notification message and title to the message
                    var summary = $"Push notification received:" +
                                        $"\n\tNotification title: {e.Title}" +
                                        $"\n\tMessage: {e.Message}";

                    // If there is custom data associated with the notification,
                    // print the entries
                    if (e.CustomData != null)
                    {
                        summary += "\n\tCustom data:\n";
                        foreach (var key in e.CustomData.Keys)
                        {
                            summary += $"\t\t{key} : {e.CustomData[key]}\n";
                        }
                    }

                    // Send the notification summary to debug output
                    System.Diagnostics.Debug.WriteLine(summary);
                };
            }

        }

        async void abc()
        {
            System.Guid? installId = await AppCenter.GetInstallIdAsync();
            System.Diagnostics.Debug.WriteLine("MTG : " + installId);
            AppCenter.SetUserId(installId.ToString());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("ios=db53fbdd-1b17-45b5-8b21-ce008cc53778;" + "uwp=04b94821-b30b-4219-b2e6-c5eb2a1325e6;" + "android=5c9910e1-d44b-4489-b283-0ac71fab54c5;", typeof(Analytics), typeof(Crashes), typeof(Push));

            abc();
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
