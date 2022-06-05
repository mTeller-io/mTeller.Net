using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// The class for town object
    /// </summary>
    public class Town
    {
        //The identity primary key field
        [Key]
        public int TownId { get; set; }

        //The global unique id
        public Guid TownUId = Guid.NewGuid();

        //The town name
        public string Name { get; set; }

        //The town description
        public string Description { get; set; }

        //The city id
        public int CityId { get; set; }

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