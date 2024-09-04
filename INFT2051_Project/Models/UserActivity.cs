using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFT2051_Project.Models
{
    [Table("UserActivityLog")]
    public class UserActivity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Date {  get; set; }

        public bool answeredQuestion { get; set; }
    }
}
