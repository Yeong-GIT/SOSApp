using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace SOSApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelpRecord : ContentPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SOSApp.txt");

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            displayRecord.ItemsSource = await firebaseHelper.GetAllSOSRecord();
        }

        public HelpRecord()
        {
            InitializeComponent();
            //displayRecord.Text = File.ReadAllText(fileName);
        }
    }
}