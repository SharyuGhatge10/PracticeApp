using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Tourisum.Model;

namespace Tourisum.Helpers
{
    public static class Settings
    {

        /// <summary>
        /// This is the Settings static class that can be used in your Core solution or in any
        /// of your client applications. All settings are laid out the same exact way with getters
        /// and setters. 
        /// </summary>

        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = "Yes";

        private const string UserNameKey = "username_key";
        private static readonly string UserNameDefault = string.Empty;

        //  private static UserDetails userDetail = "userdetailkey";


        #endregion


        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        public static string GetUserName
        {
            get
            {
                return AppSettings.GetValueOrDefault(UserNameKey, UserNameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(UserNameKey, value);
            }
        }

        //public static UserDetails StoreUser
        //{
        //    get
        //    {
        //        return userDetail;
        //    }
        //    set
        //    {
        //        userDetail = value;
        //    }
        //}

        //public static UserDetails StoreUser
        //{
        //    get
        //    {
        //       return AppSettings.GetValueOrDefault (userDetail , null);

        //    }
        //    set
        //    {
        //        AppSettings.AddOrUpdateValue(userDetail, value);
        //    }
        //}

    }
}



