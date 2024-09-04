using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INFT2051_Project.Models;
using SQLite;

namespace INFT2051_Project.Services
{
    
    internal static class DatabaseService
    {
        private static string _databaseFileTopic;
        public static string DatabaseFileTopic
        {
            get 
            {
                if (_databaseFileTopic == null)
                {
                    string databaseDir = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "data");
                    System.IO.Directory.CreateDirectory(databaseDir);
                    _databaseFileTopic = Path.Combine(databaseDir, "TopicData.db3");
                }
                return _databaseFileTopic;
            }
        }

        private static SQLiteConnection _connectionTopic;
        public static SQLiteConnection ConnectionTopic
        {
            get
            {
                if (_connectionTopic == null)
                {
                    _connectionTopic = new SQLiteConnection(DatabaseFileTopic);
                    _connectionTopic.CreateTable<TopicData>();      
                }
                return _connectionTopic;
            }
        }

        private static string _databaseFileDate;

        public static string DatabaseFileDate
        {
            get
            {
                if (_databaseFileDate == null)
                {
                    string databaseDir = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "data");
                    System.IO.Directory.CreateDirectory(databaseDir);
                    _databaseFileDate = Path.Combine(databaseDir, "ActivityData.db3");
                }
                return _databaseFileDate;
            }
        }

        private static SQLiteConnection _connectionDate;
        public static SQLiteConnection ConnectionDate
        {
            get
            {
                if (_connectionDate == null)
                {
                    _connectionDate = new SQLiteConnection(DatabaseFileDate);
                    _connectionDate.CreateTable<UserActivity>();
                }
                return _connectionDate;
            }
        }
    }  
}
