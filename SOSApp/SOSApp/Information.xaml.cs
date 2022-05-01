using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace SOSApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Information : ContentPage
    {
        public Information()
        {
            InitializeComponent();
        }
        async void OnInfoClicked(object sender, EventArgs args)
        {
            await Browser.OpenAsync(" http://infobanjirjps.selangor.gov.my/faq.html", BrowserLaunchMode.SystemPreferred);

        }

        async void OnToDoListClicked(object sender, EventArgs args)
        {

            await Browser.OpenAsync(" https://www.youtube.com/watch?v=43M5mZuzHF8", BrowserLaunchMode.SystemPreferred);

        }

        async void OnEvacuationClicked(object sender, EventArgs args)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                await Launcher.OpenAsync("http://maps.apple.com/?daddr=Sports+Arena+@+UNITEN");
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                await Launcher.OpenAsync("http://maps.google.com/?daddr=Sports+Arena+@+UNITEN");
            }


        }

    }
}