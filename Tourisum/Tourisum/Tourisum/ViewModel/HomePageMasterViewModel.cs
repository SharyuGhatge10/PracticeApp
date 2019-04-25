using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Tourisum.Helpers;
using Tourisum.Model;

namespace Tourisum.ViewModel
{
    public class HomePageMasterViewModel : INotifyPropertyChanged
    {
        #region Selected Item
        private ObservableCollection<MenuPageContents> _menuPageContents;

        public ObservableCollection<MenuPageContents> menuPageContents
        {
            get
            {
                return _menuPageContents;
            }
            set
            {
                _menuPageContents = value;
                OnPropertyChangedList(nameof(_menuPageContents));
            }
        }
        #endregion
        private void OnPropertyChangedList(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        #region Selected Item
        private MenuPageContents SelectedmenuPageContents;

        public event PropertyChangedEventHandler PropertyChanged;
        public MenuPageContents _SelectedmenuPageContents
        {
            get { return SelectedmenuPageContents; }
            set
            {
                SelectedmenuPageContents = value;
                OnPropertyChanged(nameof(SelectedmenuPageContents));
                InitAsync();
            }
        }

        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
        #endregion

        #region Login user state save
        public string login = Settings.GeneralSettings;
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                if (login == value)
                    return;

                login = value;
                OnPropertyChangedLogin(nameof(login));
            }

        }

        private void OnPropertyChangedLogin(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
        #endregion

        public UserDetails UserDetailsHomePageMasterView { get; set; }
        
        public string SignInNameHome { get; set; }

        public HomePageMasterViewModel(UserDetails _UserDetailsHomePageMasterView)
        {
            menuPageContents = new ObservableCollection<MenuPageContents>
            {
               new MenuPageContents("profileimage.png","Profile"),
                new MenuPageContents("places.png","Places"),
                new MenuPageContents("booking1.jfif","Bookings"),
                new MenuPageContents("services1.png","Services"),
                new MenuPageContents("offers.png","Offers"),
                new MenuPageContents("logout1.jfif","LogOut"),
            };

            UserDetailsHomePageMasterView = _UserDetailsHomePageMasterView;

            SignInNameHome = Settings.GetUserName;
        }

        

        private async void InitAsync()
        {
            if (SelectedmenuPageContents != null)
            {
                if (SelectedmenuPageContents._MenuPageContentlLabel.Contains("LogOut"))
                {
                    var result = await App.Current.MainPage.DisplayAlert("Log Out", "Do you really want to log out ?", "Yes", "No");

                    if(result)
                    {
                        if (Login == "no")
                        {
                            Settings.GeneralSettings = "Yes";
                            await App.NavigationService.PushAsync(App.LogoutPageKey);
                        }
                    }
                }
                else if(SelectedmenuPageContents._MenuPageContentlLabel.Contains("Profile"))
                {
                    await App.NavigationService.PushAsync(App.ProfilePageKey);
                }
            }
        }
    }
}

//private async void InitAsync()
//{
//    try
//    {
//        if (SelectedmenuPageContents != null)
//        {
//            if (SelectedmenuPageContents._MenuPageContentlLabel.Contains("LogOut"))
//            {
//                //UserDialogs.Instance.Alert("title", "message", "OK");
//                //UserDialogs.Instance.Prompt("message", "title", "okText", "cancelText", "", InputType.Default, null);
//                //var args = new AlertArguments(title, message, accept, cancel);
//                //MessagingCenter.Send(this, AlertSignalName, args);
//                var result = await App.Current.MainPage.DisplayAlert("Log Out", "Do you really want to log out ?", "Yes", "No");
//                if (result)
//                {
//                    //UserDetailsHomePageMasterView = new UserDetails();
//                    //UserDetails = await App.SQLiteDb.DeleteUserAsync(UserDetails user);
//                    //await App.SQLiteDb.DeleteUserAsync(UserDetails user);

//                    //_UserDetails = await App.SQLiteDb.GetUserAsync(SignInNameHome);

//                    int deletresult = await deletUser(UserDetailsHomePageMasterView);
//                    if (deletresult == 1)
//                    {

//                        //Device.BeginInvokeOnMainThread(async () =>
//                        //{
//                        //    await App.NavigationService.PushAsync(App.LogoutPageKey);
//                        //});
//                    }

//                    //  x = await App.SQLiteDb.DeleteUserAsync(UserDetailsHomePageMasterView);
//                    //return x;
//                }
//            }
//        }

//    }
//    catch (Exception e)
//    {

//    }
//}

//private async Task<int> deletUser(UserDetails UserDetailsHomePageMasterView)
//{
//    //UserDetails = new UserDetails();
//    int x = await App.SQLiteDb.DeleteUserAsync(UserDetailsHomePageMasterView);

//    return x;
//}


