using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourisum.Model;
using Tourisum.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tourisum.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePageMaster : ContentPage
	{
        public ListView ListView;


        public HomePageMaster()
        {
            InitializeComponent();
            
        }
        
        public void Init(UserDetails userDetails)
        {
            BindingContext = new HomePageMasterViewModel(userDetails);
            ListView = MenuItemsListView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}