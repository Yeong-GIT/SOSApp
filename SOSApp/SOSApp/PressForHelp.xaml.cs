using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace SOSApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PressForHelp : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SOSApp.txt");

        public PressForHelp()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var result = await Geolocation.GetLocationAsync(new
                GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromMinutes(1)));
            resultLocation.Text = $"Latitude:{result.Latitude}\nLogitude:{result.Longitude}\nAltitude:{result.Altitude}\nTime:{result.Timestamp}";
        }



        void OnCalculateTotal(object sender, EventArgs e)
        {
            var elderly = 0;
            var adult = 0;
            var children = 0;
            var total = 0;

            if ((int.TryParse(inputElderly.Text, out elderly)) && (int.TryParse(inputAdult.Text, out adult)) && (int.TryParse(inputChildren.Text, out children)))
            {
                total = elderly + adult + children;
                outputResult.Text = string.Format("{0:##}", total);

            }
            else
            {
                outputResult.Text = "NA";
                
            }

            if ((total <= 2) && (elderly <= 1) && (adult < 2) && (children <= 1))
            {
                outputVictimStatus.Text = "C3 Urgency";
                outputVictimStatus.BackgroundColor = Color.Yellow;
                outputVictimStatus.TextColor = default;
            }
            else if ((total <= 4) && (elderly <= 2) && (adult < 3) && (children <= 2))
            {
                outputVictimStatus.Text = "C2 Urgency";
                outputVictimStatus.BackgroundColor = Color.Orange;
                outputVictimStatus.TextColor = Color.White;
            }
            else if((total >= 5) || (elderly > 2) || (adult > 4) || (children >= 3))
            {
                outputVictimStatus.Text = "C1 Urgency";
                outputVictimStatus.BackgroundColor = Color.Red;
                outputVictimStatus.TextColor = Color.White;
            }
            else
            {
                outputVictimStatus.Text = "C1 Urgency";
                outputVictimStatus.BackgroundColor = Color.Orange;
                outputVictimStatus.TextColor = Color.White;
            }
        }

        void OnGetLocation(object sender, EventArgs e)
        {
            var latitude = 0.0000;
            var longtitude = 0.0000;
            var altitude = 0.0000;

            if ((Double.TryParse(inputLat.Text, out latitude)) && (Double.TryParse(inputLong.Text, out longtitude)) && (Double.TryParse(inputAlt.Text, out altitude)))
            {

            }
            else
            {
                outputResult.Text = "Please enter a valid value";
            }

        }

        async void OnSaveRecord(object sender, EventArgs e)
        {
            /*var writerRecord = 
                "\nElderly: " + inputElderly.Text +
                "\nAdult: " + inputAdult.Text +
                "\nChildren: " + inputChildren.Text +
                "\nLatitude: " + inputLat.Text +
                "\nLongtitude: " + inputLong.Text +
                "\nAltitude: " + inputAlt.Text +
                "\nTotal: " + outputResult.Text +
                "\nV.Status: " + outputVictimStatus.Text +
                "\n";
            File.AppendAllText(fileName, writerRecord + Environment.NewLine);*/

            var elderly = int.Parse(inputElderly.Text);
            var adult = int.Parse(inputAdult.Text);
            var children = int.Parse(inputChildren.Text);
            var totalvictim = int.Parse(outputResult.Text);
            var latitude = double.Parse(inputLat.Text);
            var longtitude = double.Parse(inputLong.Text);
            var altitude = Double.Parse(inputAlt.Text);
            string status = outputVictimStatus.Text;
            await firebaseHelper.AddRecord(elderly, adult, children, totalvictim, latitude, longtitude, altitude, status);

            await DisplayAlert("Record Saved", "Help Record has been saved", "OK");

        }

    }
}