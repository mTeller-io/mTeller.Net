using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Feature
    {
        //primary key
        [Key]
        public int FeatureId { get; set; }

        //The global unique field
        public Guid FeatureUId = Guid.NewGuid();

        //foreign key to the Entity
        public int EntitypeID { get; set; }

        //Name of the feature
        public string Name { get; set; }

        // Description
        public string Description { get; set; }

        //User name of the created the record
        public string CreateUserName { get; set; }

        //Creation date of the record
        public DateTime CreateDateTime { get; set; }

        //The modify user name
        public string ModifyUserName { get; set; }

        //The datetime of modification
        public DateTime ModifyDateTime { get; set; }
    }
}