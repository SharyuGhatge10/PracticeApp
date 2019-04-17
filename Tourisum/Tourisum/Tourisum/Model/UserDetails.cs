using SQLite;
using System;

namespace Tourisum.Model
{
    public class UserDetails 
    {
        [AutoIncrement , PrimaryKey]
        public int userID { get; set; }
        public string userName { get; set; }
        public DateTime userDateOfBIrth { get; set; }
        public string userEmail { get; set; }
        public double userPhoneNo { get; set; }
        public string userPassword { get; set; }

        public UserDetails()
        {

        }

    }
}
