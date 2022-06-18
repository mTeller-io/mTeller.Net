using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// The class for region object
    /// </summary>
    public class Region
    {
        //The identity primary key field
        [Key]
        public int RegionId { get; set; }

        //The global unique id
        public Guid RegionUId = Guid.NewGuid();

        //The city name
        public string Name { get; set; }

        //The city description
        public string Description { get; set; }

        //The country id
        public int CountryId { get; set; }

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