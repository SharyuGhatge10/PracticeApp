using System;
using System.ComponentModel;
using System.Windows.Input;
using Tourisum.Helpers;
using Tourisum.Model;
using Xamarin.Forms;

namespace Tourisum.ViewModel
{

    public class RegisterViewModel : INotifyPropertyChanged
    {
        DateTime registerDOB = DateTime.Now;
        public string registerName { get; set; }
        public DateTime RegisterDOB = DateTime.UtcNow;
        public string registerEmail { get; set; }
        public int registerPhoneNumber { get; set; }
        public string registerPassword { get; set; }

        public string RegisterGender { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public ICommand RegisterPageButtonCommand { get; set; }
        public RegisterViewModel()
        {
            RegisterPageButtonCommand = new Command(RegisterPageButton);

        }
  
        private async void RegisterPageButton(object obj)
        {
            try
            {
                if(!string.IsNullOrEmpty(registerName) && !string.IsNullOrEmpty(registerDOB.ToString()) && !string.IsNullOrEmpty(registerEmail) && !string.IsNullOrEmpty(registerPassword))
                {
                    UserDetails user = new UserDetails();
                    user.userName = registerName.Trim();
                    user.userGender = RegisterGender;
                    user.userDateOfBIrth = registerDOB;
                    user.userEmail = registerEmail;
                    user.userPhoneNo = registerPhoneNumber;
                    user.userPassword = registerPassword.Trim();

                    var result = await App.SQLiteDb.SaveUserAsyncNew(user);

                    if (result)
                    {
                        Settings.GetUserName = user.userName;
                        await App.Current.MainPage.DisplayAlert("Registration Process", "Registration Successfull...!!!", "OK");
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            App.NavigationService.PushAsync(App.SignInPageKey);
                        });
                    }
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Registration Failure", "Please enter all the fields for registration...!!!", "OK");
                }
                
            }
            catch (Exception ex)
            {

            }
        }
    }
}
