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
        static TopicData oneStepData = new TopicData()     //creating a blank TopicData
        {
            Id = 1,
            TopicName = "One Step Equations",
            TotalQuestionsAttempted = 0,
            TotalQuestionsCorrect = 2
        };
        static TopicData twoStepData = new TopicData()     //creating a blank TopicData
        {
            Id = 2,
            TopicName = "One Step Equations",
            TotalQuestionsAttempted = 0,
            TotalQuestionsCorrect = 2
        };
        static TopicData QuadraticData = new TopicData()     //creating a blank TopicData
        {
            Id = 3,
            TopicName = "One Step Equations",
            TotalQuestionsAttempted = 0,
            TotalQuestionsCorrect = 2
        };
        static TopicData fracData = new TopicData()     //creating a blank TopicData
        {
            Id = 4,
            TopicName = "One Step Equations",
            TotalQuestionsAttempted = 0,
            TotalQuestionsCorrect = 2
        };
        static TopicData deciData = new TopicData()     //creating a blank TopicData
        {
            Id = 5,
            TopicName = "One Step Equations",
            TotalQuestionsAttempted = 0,
            TotalQuestionsCorrect = 2
        };
        static TopicData percData = new TopicData()     //creating a blank TopicData
        {
            Id = 6,
            TopicName = "One Step Equations",
            TotalQuestionsAttempted = 0,
            TotalQuestionsCorrect = 2
        };

        static public List<TopicData> topicData = new List<TopicData>
        {
          new TopicData()     //creating a blank TopicData
            {
                Id = 1,
                TopicName = "One Step Equations",
                TotalQuestionsAttempted = 0,
                TotalQuestionsCorrect = 0
            },

          new TopicData()     //creating a blank TopicData
            {
                Id = 2,
                TopicName = "Two Step Equations",
                TotalQuestionsAttempted = 0,
                TotalQuestionsCorrect = 0
            },
          new TopicData()     //creating a blank TopicData
            {
                Id = 3,
                TopicName = "Quadratic Equations",
                TotalQuestionsAttempted = 0,
                TotalQuestionsCorrect = 0
            },
          new TopicData()     //creating a blank TopicData
            {
                Id = 4,
                TopicName = "Converting to Fractions",
                TotalQuestionsAttempted = 0,
                TotalQuestionsCorrect = 0
            },
          new TopicData()     //creating a blank TopicData
            {
                Id = 5,
                TopicName = "Converting to Decimals",
                TotalQuestionsAttempted = 0,
                TotalQuestionsCorrect = 0
            },
          new TopicData()     //creating a blank TopicData
            {
                Id = 6,
                TopicName = "Converting to Percentages",
                TotalQuestionsAttempted = 0,
                TotalQuestionsCorrect = 0
            }
        };

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
