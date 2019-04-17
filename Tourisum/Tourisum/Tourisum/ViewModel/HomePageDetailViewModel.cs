using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tourisum.Model;
using Xamarin.Forms;

namespace Tourisum.ViewModel
{
     public class HomePageDetailViewModel
     {
        // public ObservableCollection<FileImageSource> _CaroselItems { get; set; }

        public ObservableCollection<ListOfBooking> ListofBookings { get; set; }
        public HomePageDetailViewModel()
        {
            //try {
            //    _CaroselItems = new ObservableCollection<FileImageSource>
            //    {
            //     _CaroselItems.Add("index1.png"),
            //    _CaroselItems.Add("index2.jfif"),
            //    _CaroselItems.Add("images3.jfif"),
            //    _CaroselItems.Add("images4.jfif")
            //};

            //}
            //catch(Exception e)
            //{

            //}


            ListofBookings = new ObservableCollection<ListOfBooking>
            {
               new ListOfBooking("Kolhapur","Pune",2),
                new ListOfBooking("Kolhapur","Pune",2),
                new ListOfBooking("Kolhapur","Pune",2),
                new ListOfBooking("Kolhapur","Pune",2),
                new ListOfBooking("Kolhapur","Pune",2),
                new ListOfBooking("Kolhapur","Pune",2),
                new ListOfBooking("Kolhapur","Pune",2),
                new ListOfBooking("Kolhapur","Pune",2),
                new ListOfBooking("Kolhapur","Pune",2),
                new ListOfBooking("Kolhapur","Pune",2),
                new ListOfBooking("Kolhapur","Pune",2),
                new ListOfBooking("Kolhapur","Pune",2),
            };

        }
            
        
    }
}
