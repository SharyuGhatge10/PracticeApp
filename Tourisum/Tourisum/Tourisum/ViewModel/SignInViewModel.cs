using System;
using System.ComponentModel;
using System.Windows.Input;
using Tourisum.Helpers;
using Tourisum.Model;
using Xamarin.Forms;

namespace Tourisum.ViewModel
{
    public class SignInViewModel : INotifyPropertyChanged
    {
        
        public string SignInName { get; set; }
        public string SigninPAssword { get; set; }
        public UserDetails UserDetailsSiginInView { get; set; }
        public ICommand SignInPageButton_Clicked { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public string login = Settings.GeneralSettings;
        public string Login
        {
            get => login;
            set
            {
                if (login == value)
                    return;

                login = value;
                OnPropertyChanged(nameof(login));
            }

        }

        //public UserDetails storeUser = Settings.StoreUser;
        //public UserDetails _storeUser
        //{
        //    get
        //    {
        //        return storeUser;
        //    }
        //    set
        //    {
        //        if(storeUser == value)
        //            return;

        //        storeUser = value;
        //        OnPropertyChanged(nameof(storeUser));
        //    }
        //}

        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public SignInViewModel()
        {
            SignInPageButton_Clicked = new Command(SignInPageCommand);

        }


        private async void SignInPageCommand(object obj)
        {

            if (Login == "Yes")
            {
                Settings.GeneralSettings = "no";
            }

    
            UserDetailsSiginInView = new UserDetails();
          

            if (string.IsNullOrEmpty(SignInName) || string.IsNullOrEmpty(SigninPAssword))
            {
                await App.Current.MainPage.DisplayAlert("Login Failure", "Please enter Login name and Password to login ...!!!", "OK");
            }
            else
            {
                SignInName = SignInName.Trim();
                SigninPAssword = SigninPAssword.Trim();

                if (UserDetailsSiginInView != null)
                {
                    UserDetailsSiginInView = await App.SQLiteDb.GetUserAsync(SignInName);

                    //_storeUser = UserDetailsSiginInView;

                    //if (_storeUser != null)
                    //{
                    //    Settings.StoreUser = UserDetailsSiginInView;
                    //}

                    Settings.GetUserName = UserDetailsSiginInView.userName;

                    if (UserDetailsSiginInView == null)
                    {
                        await App.Current.MainPage.DisplayAlert("Login Failure", "Invalid Usename or Password...!!!", "OK");
                    }

                    else
                    {
                        if (SignInName.Equals(this.UserDetailsSiginInView.userName) && SigninPAssword.Equals(this.UserDetailsSiginInView.userPassword))
                        {
                            App.UserApp = UserDetailsSiginInView;
                            await App.NavigationService.PushAsync(App.HomePageKey, UserDetailsSiginInView);
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Login Failure", "Invalid Usename or Password...!!!", "OK");
                        }
                    }
                   
                }

                
            }
        }

    }
}


