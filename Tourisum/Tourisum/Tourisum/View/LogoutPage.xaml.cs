using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tourisum.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogoutPage : ContentPage
	{
		public LogoutPage ()
		{
			InitializeComponent ();
		}

        private void SignInButton_Clicked(object sender, EventArgs e)
        {
            App.NavigationService.PushAsync(App.SignInPageKey);
        }
    }
}