using System;
using System.IO;
using System.Threading.Tasks;
using Tourisum.Helpers;
using Tourisum.Model;
using Tourisum.Navigation;
using Tourisum.SQLite_database;
using Tourisum.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Tourisum
{
    public partial class App : Application
    {
        static SQLiteHelper db;

        public  string IsFirstTime
        {
            get { return Settings.GeneralSettings; }
            set
            {
                if (Settings.GeneralSettings == value)
                    return;
                Settings.GeneralSettings = value;
                OnPropertyChanged();
            }
        }

        public static UserDetails UserApp { get; set; }

        public UserDetails userd = new UserDetails();

        #region INavigation
        public static INavigationService NavigationService { get; } = new NavigationService();
        public static readonly string HomePageKey = "HomePage";
        public static readonly string RegisterPageKey = "RegisterPage";
        public static readonly string SignInPageKey = "SignInPage";
        public static readonly string HomePageMasterKey = "HomePageMaster";
        public static readonly string HomePageDetailKey = "HomePageDetail";
        public static readonly string LogoutPageKey = "LogoutPage";
        public static readonly string ProfilePageKey = "ProfilePage";


        #endregion
        public  App()
        {
            InitializeComponent();

            Current = this;
            NavigationService.Configure(HomePageKey, typeof(HomePage));
            NavigationService.Configure(RegisterPageKey, typeof(RegisterPage));
            NavigationService.Configure(SignInPageKey, typeof(SignInPage));
            NavigationService.Configure(HomePageMasterKey, typeof(HomePageMaster));
            NavigationService.Configure(HomePageDetailKey, typeof(HomePageDetail));
            NavigationService.Configure(LogoutPageKey, typeof(LogoutPage));
            NavigationService.Configure(ProfilePageKey, typeof(ProfilePage));
            db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MySQLite.db3"));

            //MainPage = new NavigationPage(new ProfilePage());

            if (IsFirstTime == "Yes")
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                string user = Settings.GetUserName;
                if (user != null)
                {
                    GetObject(user);
                }
                else
                {
                    MainPage = new NavigationPage(new MainPage());
                }
            }
        }

        private async void GetObject(string user)
        {
            userd = await GetUser(user);
            if (userd != null)
            {
                MainPage = new NavigationPage(new HomePage(userd));
            }
        }

        private async Task<UserDetails> GetUser(string user)
        {
            UserDetails userDetails = new UserDetails();
            userDetails = await App.SQLiteDb.GetUserAsync(user);
            return userDetails;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static SQLiteHelper SQLiteDb
        {
            get
            {
                return db;
            }
        }
    }
}
