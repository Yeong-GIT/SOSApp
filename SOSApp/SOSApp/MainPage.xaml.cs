using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SOSApp
{
    public partial class MainPage : ContentPage
    {
        private readonly Geocoder _geocoder = new Geocoder();
        public MainPage()
        {
            InitializeComponent();
        }

        async void Map_MapClicked(object sender, Xamarin.Forms.Maps.MapClickedEventArgs e)
        {
            await DisplayAlert("Coordinates", $"Lat:{e.Position.Latitude}, Long:{e.Position.Longitude}", "OK");

            var addresses = await _geocoder.GetAddressesForPositionAsync(e.Position);

            await DisplayAlert("Address", addresses.FirstOrDefault()?.ToString(), "OK");
        }
    }
}
