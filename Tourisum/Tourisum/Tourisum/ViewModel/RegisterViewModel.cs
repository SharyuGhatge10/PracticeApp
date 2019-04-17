using System;
using System.Windows.Input;
using Tourisum.Model;
using Xamarin.Forms;

namespace Tourisum.ViewModel
{

    public class RegisterViewModel
    {
        DateTime registerDOB = DateTime.Now;
        public string registerName { get; set; }
        public DateTime RegisterDOB = DateTime.UtcNow;
        public string registerEmail { get; set; }
        public int registerPhoneNumber { get; set; }
        public string registerPassword { get; set; }


        public ICommand RegisterPageButtonCommand { get; set; }
        public RegisterViewModel()
        {
            RegisterPageButtonCommand = new Command(RegisterPageButton);
        }

        private async void RegisterPageButton(object obj)
        {
            try
            {
                UserDetails user = new UserDetails();
                user.userName = registerName;
                user.userDateOfBIrth = registerDOB;
                user.userEmail = registerEmail;
                user.userPhoneNo = registerPhoneNumber;
                user.userPassword = registerPassword;

                var result = await App.SQLiteDb.SaveUserAsyncNew(user);

                if(result)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        App.NavigationService.PushAsync(App.SignInPageKey);
                    });
                }

                else
                {
                   
                }
                
            }
            catch (Exception ex)
            {

            }
        }
    }
}
