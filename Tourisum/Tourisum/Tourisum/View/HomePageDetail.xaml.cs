using System;
using System.Collections.ObjectModel;
using Tourisum.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tourisum.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageDetail : ContentPage
    {
        public ObservableCollection<FileImageSource> _CaroselItems = new ObservableCollection<FileImageSource>();

        public ListView ListView;
        public HomePageDetail()
        {
            try
            {
                InitializeComponent();

                _CaroselItems.Add("index1.png");
                _CaroselItems.Add("index2.jfif");
                _CaroselItems.Add("images3.jfif");
                _CaroselItems.Add("images4.jfif");
                CaroselView.ItemsSource = _CaroselItems;

                ListView = BokkingDetailsList;

                this.BindingContext = new HomePageDetailViewModel();
            }
            catch (Exception ex)
            {

            }
        }

       
        private void FAB_Clicked(object sender, EventArgs e)
        {

        }
    }
}