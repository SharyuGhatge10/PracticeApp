using System;
using System.IO;
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

        #region INavigation
        public static INavigationService NavigationService { get; } = new NavigationService();
        public static readonly string HomePageKey = "HomePage";
        public static readonly string RegisterPageKey = "RegisterPage";
        public static readonly string SignInPageKey = "SignInPage";
        public static readonly string HomePageMasterKey = "HomePageMaster";
        public static readonly string HomePageDetailKey = "HomePageDetail";
        #endregion
        public App()
        {
            InitializeComponent();

            Current = this;
            NavigationService.Configure(HomePageKey, typeof(HomePage));
            NavigationService.Configure(RegisterPageKey, typeof(RegisterPage));
            NavigationService.Configure(SignInPageKey, typeof(SignInPage));
            NavigationService.Configure(HomePageMasterKey, typeof(HomePageMaster));
            NavigationService.Configure(HomePageDetailKey, typeof(HomePageDetail));
            db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MySQLite.db3"));
            MainPage = new NavigationPage(new HomePage());
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
