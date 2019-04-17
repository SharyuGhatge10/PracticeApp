using System.Collections.Generic;
using Tourisum.Model;

namespace Tourisum.ViewModel
{
    public class MenuPageViewModel
    {
        public string _MenuPageImage { get; set; }
        public string _MenuPageLabel { get; set; }
        public List<MenuPageContents> _MenuPageListView { get; set; }
        public MenuPageViewModel()
        {
            _MenuPageListView = new List<MenuPageContents>
            {
                new MenuPageContents("icon.png","Setting"),
                new MenuPageContents("icon.png","Offers"),
                new MenuPageContents("icon.png","Log Out"),
            };

        }
    }
}
