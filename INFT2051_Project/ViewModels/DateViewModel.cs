using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using INFT2051_Project.Services;
using INFT2051_Project.Models;

namespace INFT2051_Project.ViewModels
{
    internal class DateViewModel : ObservableObject
    {
        public static DateViewModel Current { get; set; }

        SQLiteConnection connection;

        public DateViewModel()
        {
            Current = this;
            connection = DatabaseService.ConnectionDate;
        }

        public List<UserActivity> Dates
        {
            get
            {
                return connection.Table<UserActivity>().ToList();
            }
        }

        public void SaveData(UserActivity data)    //this function looks bad but works. So I am not  arguing
        {
            var date = new UserActivity()
            {
                Id = data.Id,
                Date = data.Date,
                answeredQuestion = data.answeredQuestion,
            };

            if (Dates.Any(x => x.Date == data.Date))
            {
                connection.Update(date);
            }
            else
            {
                connection.Insert(date);
            }
        }

        public void DeleteData(UserActivity data)
        {
            if (data.Id > 0)
            {
                connection.Delete(data);
            }
        }

        //Function to get the data from the database, based on the attributes of the passed topic data.
        public UserActivity getDateData(UserActivity data)
        {

            var result = Dates.Where(x => x.Date == data.Date);
            var date = result.FirstOrDefault();
            data = date;
            return data;
        }
    }
}
