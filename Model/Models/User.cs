using System;
using System.ComponentModel.DataAnnotations;

namespace Model 
{
    public class User
    {
        //The identity primary key
        public int UserId { get; set; }
        //The global unique identifier
        public Guid UserUId = Guid.NewGuid();
        //The user define login name
        [Required]
        public string UserName { get; set; }
        //The full name of the user
        [Required]
        public string UserFullName { get; set; }
        // The hash login password of the user
        [Required]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        //Login password expiry date
        [Required]
        public DateTime PasswordExpiryDate { get; set; }
        // The id of the user assigned role from the roles object
        public int UserRoleID { get; set; }
        // The brancode of the user assigned branch
        [Required]
        public string BranchCode { get; set; }
        // The mailing address of the user
        [Required]
        public string MailingAddress { get; set; }
        // The GPS Ghana Post Code of the user
        public string GhanaPostCode { get; set; }
        // The mobile number of the user
        [Required]
        public string MobileNumber { get; set; }
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