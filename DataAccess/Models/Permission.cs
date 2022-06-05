using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// The table for storing permissions
    /// </summary>
    public class Permission
    {
        //The identity auto primary key
        [Key]
        public int PermissionId { get; set; }

        //The global UId
        public Guid PermissonUId = Guid.NewGuid();

        //The id of the feature the permissons applying to
        public int FeatureId { get; set; }

        //The read or view access flag
        public int Read { get; set; }

        //The edit or modify access flag
        public int Modify { get; set; }

        //The create or add access flag
        public int Add { get; set; }

        //The remove or delete access glag
        public int Delete { get; set; }

        //The username granted the permisison on the feature id
        public string UserName { get; set; }

        //The entity type id of the permission table
        public int EntitypeID { get; set; }

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