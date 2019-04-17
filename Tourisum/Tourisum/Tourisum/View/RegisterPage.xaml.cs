using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourisum.Validation;
using Tourisum.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tourisum.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();

            var viewModel = new RegisterViewModel();
            this.BindingContext = viewModel;
        }

        //private void Name_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    bool result = Validations.FullNameIsValid(e.NewTextValue);
        //    if (!result)
        //    {
        //        Name.TextColor = Color.Red;
        //    }
        //    else
        //    {
        //        Name.TextColor = Color.Black;
        //    }
        //}

        //private void Email_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    bool result = Validations.EmailIsValid(e.NewTextValue);
        //    if (!result)
        //    {
        //        Email.TextColor = Color.Red;
        //    }
        //    else
        //    {
        //        Email.TextColor = Color.Black;
        //    }
        //}

        //private void PhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    //bool result = Validations.PreparePhoneNumber(e.NewTextValue);

        //    if(e.NewTextValue.Length<10)
        //    {
        //        PhoneNumber.TextColor = Color.Red;
        //    }
        //    else
        //    {
        //        PhoneNumber.TextColor = Color.Black;
        //    }
        //}
    }
}