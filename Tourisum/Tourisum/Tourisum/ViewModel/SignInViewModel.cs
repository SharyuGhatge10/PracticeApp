using System;
using System.Windows.Input;
using Tourisum.Model;
using Xamarin.Forms;

namespace Tourisum.ViewModel
{
    public class SignInViewModel
    {
        public string SignInName { get; set; }
        public string SigninPAssword { get; set; }
        public UserDetails UserDetails { get; set; }

        public ICommand SignInPageButton_Clicked { get; set; }
        public SignInViewModel()
        {
            SignInPageButton_Clicked = new Command(SignInPageCommand);
        }

        private async void SignInPageCommand(object obj)
        {
            try
            {
                if (UserDetails == null)
                    UserDetails = new UserDetails();

                UserDetails = await App.SQLiteDb.GetUserAsync(SignInName);

                if (!string.IsNullOrEmpty(this.UserDetails.userName) && !string.IsNullOrEmpty(this.UserDetails.userPassword))
                {
                    if (SignInName.Equals(this.UserDetails.userName) && SigninPAssword.Equals(this.UserDetails.userPassword))
                    {
                        await App.NavigationService.PushAsync(App.HomePageKey);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

