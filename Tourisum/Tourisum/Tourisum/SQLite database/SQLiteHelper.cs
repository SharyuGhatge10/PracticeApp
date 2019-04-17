using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tourisum.Model;

namespace Tourisum.SQLite_database
{
    public class SQLiteHelper
    {
        readonly SQLiteAsyncConnection db;
        //public SQLiteConnection conn;
        //public UserDetails userDetails;
        public SQLiteHelper(string path)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            db = new SQLiteAsyncConnection(path);
            Init();
        }
        public async Task Init()
        {
            await db.CreateTableAsync<UserDetails>();
        }



        //Insert and Update new record  
        public async Task<bool> SaveUserAsyncNew(UserDetails userDetails)
        {
            try
            {
                var data = await db.Table<UserDetails>().ToListAsync();
                var result = await db.InsertAsync(userDetails);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


        //Delete  
        public Task<int> DeleteUserAsync(UserDetails userDetails)
        {
            return db.DeleteAsync(userDetails);
        }

        //Read All Items  
        public Task<List<UserDetails>> GetUserAsync()
        {
            return db.Table<UserDetails>().ToListAsync();
        }


        //Read Item  
        public async Task<UserDetails> GetUserAsync(string UserName)
        {
            UserDetails user = new UserDetails();
            user = await db.Table<UserDetails>().Where(i => i.userName == UserName).FirstOrDefaultAsync();
            return user;
        }
    }
}
