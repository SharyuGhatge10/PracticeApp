using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourisum.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tourisum.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : MasterDetailPage
    {
        private readonly UserDetails userDetails;
        
        public HomePage()
        {
            InitializeComponent();
            //MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }
        public HomePage(UserDetails userDetails ): this()
        {
            this.userDetails = userDetails;
            MasterPage.Init(userDetails);
        }
    }
}