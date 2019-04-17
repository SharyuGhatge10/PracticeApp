using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourisum.Model;
using Tourisum.View;
using Xamarin.Forms;

namespace Tourisum
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<FileImageSource> imageSources = new ObservableCollection<FileImageSource>();

        public MainPage()
        {
            InitializeComponent();

            //imageSources.Add("index1.png");
            //imageSources.Add("index2.jfif");
            //imageSources.Add("images3.jfif");
            //imageSources.Add("images4.jfif");
            ////myCorouselView.ItemsSource = imageSources;
            

            //imgSlider.Images = imageSources;
        }

        private async void MainPageSigninButton_Clicked(object sender, EventArgs e)
        {
            try
            {

                await Navigation.PushAsync(new SignInPage(), true);
            }
            catch (Exception ex)
            {
            }
        }

        private async void MainPageRegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(),true);
        }
    }
}
