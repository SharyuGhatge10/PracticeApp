using System;
using System.Collections.Generic;
using System.Text;

namespace Tourisum.Model
{
    public class ListOfBooking
    {
        public string Boarding { get; set; }
        public string Departure { get; set; }
        public int Days { get; set; }

        public ListOfBooking(string _Boarding,string _Departure,int _Days)
        {
            Boarding = _Boarding;
            Departure = _Departure;
            Days = _Days;
        }
    }
}
