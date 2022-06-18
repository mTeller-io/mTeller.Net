using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    /// <summary>
    /// The class for defining user roles
    /// </summary>
    public class Role : IdentityRole<int>
    {
        //The identity role id
        [Key]
        public int RoleID { get; set; }

        //The global unique identifier
        public Guid RoleUID = Guid.NewGuid();

        //The name of the role
        public override string Name { get; set; }

        //The description of the role
        public string Description { get; set; }

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