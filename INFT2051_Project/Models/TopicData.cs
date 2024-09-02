using INFT_2051.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace INFT2051_Project.Models
{
    [Table("TopicsData")]
    public class TopicData : ObservableObject
    {
        //I need to keep the name of the topic and its associated attempted and correct questions.
        ///This is used for a percentage of correct answer
        [PrimaryKey]
        public int Id { get; set; }
        [MaxLength(100), Unique]
        public string TopicName { get; set; }

        public int TotalQuestionsAttempted { get; set; }

        public int TotalQuestionsCorrect { get; set; }

    }
}
