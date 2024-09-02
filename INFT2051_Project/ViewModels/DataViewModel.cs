using INFT_2051.Models;
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
    internal class DataViewModel : ObservableObject
    {
        public List<string> topics = new List<string> 
        { 
            "One Step Equations",
            "Two Step Equations",
            "Quadratic Equations",
            "Fractions",
            "Decimals",
            "Percentages"
        };
        public static DataViewModel Current { get; set; }

        SQLiteConnection connection;

        public DataViewModel()
        {
            Current = this;
            connection = DatabaseService.Connection;
        }

        public List<TopicData> Data
        {
            get
            {
                return connection.Table<TopicData>().ToList();
            }
        }

        public void SaveData(TopicData data)
        {
            if (data.Id > 0)
            {
                connection.Update(data);
            }
            else
            {
                connection.Insert(data);
            }
        }

        public void DeleteData(TopicData data)
        {
            if (data.Id > 0)
            {
                connection.Delete(data);
            }
        }
    }
}
