using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOSApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageSOSFlyout : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageSOSFlyout()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageSOSFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageSOSFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageSOSFlyoutMenuItem> MenuItems { get; set; }

            public MasterDetailPageSOSFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageSOSFlyoutMenuItem>(new[]
                {
                    new MasterDetailPageSOSFlyoutMenuItem { Id = 0, Title = "Find Location", TargetType=typeof(MainPage)  },
                    new MasterDetailPageSOSFlyoutMenuItem { Id = 1, Title = "Press for Help" , TargetType=typeof(PressForHelp) },
                    new MasterDetailPageSOSFlyoutMenuItem { Id = 2, Title = "Help Record" , TargetType=typeof(TabbedRecord)},
                    new MasterDetailPageSOSFlyoutMenuItem { Id = 3, Title = "Information" ,TargetType=typeof(Information) },
                    new MasterDetailPageSOSFlyoutMenuItem { Id = 4, Title = "About App" ,TargetType=typeof(AboutApp) }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}