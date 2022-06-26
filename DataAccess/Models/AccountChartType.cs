using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// The various type of account that can be found in the chart of accounts for book keeping
    /// </summary>
    public class AccountChartType
    {
        //Auto increment key
        [Key]
        public int AccountChartTypeId { get; set; }

        //Global unique key
        public Guid AccountChartTypeUId { get; set; } = Guid.NewGuid();

        //The name of the user capturing the record
        public string CreateUserName { get; set; }

        //The date and time of the captured record. Auto set with format yyyy/MM//dd H:MM SSSS
        public DateTime CreateDateTime { get; set; }

        //The user name of last modification of the record
        public string ModifyUserName { get; set; }

        //The date and time last modification of the record
        public DateTime ModifyDateTime { get; set; }
    }
}