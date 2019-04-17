﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourisum.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tourisum.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
            var viewmodel = new MenuPageViewModel();
            this.BindingContext = viewmodel;
        }
	}
}