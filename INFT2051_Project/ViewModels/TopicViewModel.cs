using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using INFT2051_Project.Services;
using INFT2051_Project.Models;
using INFT_2051.Models;

namespace INFT2051_Project.ViewModels
{
    public partial class TopicViewModel : ObservableObject
    {
        
        public static TopicViewModel Current { get; set; }
        SQLiteConnection connection;

        public TopicViewModel()
        {
            Current = this;
            connection = DatabaseService.Connection;
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
            connection.Delete(data);
        }
    }
}
