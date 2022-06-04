using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class EntityType
    {
        //The identity primary key field
        [Key]
        public int EntityId { get; set; }

        //The globale unique identifier field
        public Guid EntityUId = Guid.NewGuid();

        // The short name of the entity
        public string Name { get; set; }

        //The description of the entity
        public string Description { get; set; }

        //The database table object
        public string Table { get; set; }

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