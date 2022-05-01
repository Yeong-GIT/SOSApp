using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOSApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedRecord : TabbedPage
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        string selectedFindVictimStatus;

        async override protected void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();

            if (CurrentPage is ContentPage OverallRecordsTab)
            {
                base.OnAppearing();
                displayRecord.ItemsSource = await firebaseHelper.GetAllSOSRecord();
            }
            else if (CurrentPage is ContentPage FindStatusTab)
            {
                base.OnAppearing();
            }

        }

        async void OnFindRecord(object sender, EventArgs e)
        {
            showFindRecord.ItemsSource = await firebaseHelper.GetFindRecord(selectedFindVictimStatus);
        }

        public interface IFileHelper
        {

            void SaveLastUpdatedDateTimeForData(DateTime dateTime);

            DateTime GetLastUpdatedDateTimeForData();

        }

        public TabbedRecord()
        {
            InitializeComponent();

            findVictimStatus.Items.Add("C1 Urgency");
            findVictimStatus.Items.Add("C2 Urgency");
            findVictimStatus.Items.Add("C3 Urgency");

            findVictimStatus.SelectedIndexChanged += (sender, args) =>
            {
                if (findVictimStatus.SelectedIndex == -1)
                {
                }
                else
                {
                    selectedFindVictimStatus = findVictimStatus.Items[findVictimStatus.SelectedIndex];
                }
            };


        }
    }
}