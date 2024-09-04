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

            var topicData = new TopicData()
            {
                Id = data.Id,
                TopicName = data.TopicName,
                TotalQuestionsAttempted = data.TotalQuestionsAttempted,
                TotalQuestionsCorrect = data.TotalQuestionsCorrect
            };

            if (Data.Any(x => x.Id == topicData.Id))
            {
                if (Data.Any(x => x.TotalQuestionsAttempted == 0) && Data.Any(x => x.TotalQuestionsCorrect == 0))
                {
                    
                }
            }
            else
            {
                connection.Insert(topicData);
            }

        }

        public void DeleteData(TopicData data)
        {
            if (data.Id > 0)
            {
                connection.Delete(data);
            }
        }

        public void UpdateData(TopicData data)
        {
            var topicData = new TopicData()
            { 
                Id = data.Id,
                TopicName = data.TopicName,
                TotalQuestionsAttempted = data.TotalQuestionsAttempted,
                TotalQuestionsCorrect = data.TotalQuestionsCorrect
            };

            connection.Update(topicData);
        }

        public void InsertData(TopicData data)
        {
            connection.Insert(data);
        }

        public TopicData getTopicData(TopicData topicData)
        {
            var data = new TopicData()
            {
                Id = topicData.Id,
                TopicName = Data[topicData.Id - 1].TopicName,
                TotalQuestionsAttempted = Data[topicData.Id - 1].TotalQuestionsAttempted,
                TotalQuestionsCorrect = Data[topicData.Id - 1].TotalQuestionsCorrect,

            };
            return data;
        }
    }
}
