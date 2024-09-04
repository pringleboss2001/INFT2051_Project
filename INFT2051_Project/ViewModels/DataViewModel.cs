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
            connection = DatabaseService.ConnectionTopic;
        }

        public List<TopicData> Data
        {
            get
            {
                return connection.Table<TopicData>().ToList();
            }
        }

        public void SaveData(TopicData data)    //this function looks bad but works. So I am not  arguing
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
                    //do nothing. If it already exists.
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

        //Function to get the data from the database, based on the attributes of the passed topic data.
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
