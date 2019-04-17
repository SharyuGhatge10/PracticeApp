using System.Collections.ObjectModel;
using Tourisum.Model;

namespace Tourisum.ViewModel
{
    public class HomePageMasterViewModel
    {
        public ObservableCollection<MenuPageContents> menuPageContents { get; set; }

        public HomePageMasterViewModel()
        {
            menuPageContents = new ObservableCollection<MenuPageContents>
            {
               new MenuPageContents("icon.png","Profile"),
                new MenuPageContents("icon.png","Places"),
                new MenuPageContents("icon.png","Bookings"),
                new MenuPageContents("icon.png","Services"),
                new MenuPageContents("icon.png","Offers"),
                new MenuPageContents("icon.png","LogOut"),
            };
        }
    }
}
