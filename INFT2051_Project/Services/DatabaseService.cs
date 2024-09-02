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
        private static string _databaseFile;
        public static string DatabaseFile
        {
            get 
            {
                if (_databaseFile == null)
                {
                    string databaseDir = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "TopicData.db3");
                    System.IO.Directory.CreateDirectory(databaseDir);
                    _databaseFile = Path.Combine(databaseDir, "TopicData.db3");
                }
                return _databaseFile;
            }
        }

        private static SQLiteConnection _connection;
        public static SQLiteConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SQLiteConnection(DatabaseFile);
                    _connection.CreateTable<TopicData>();
                }
                return _connection;
            }
        }       
    }  
}
