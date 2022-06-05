namespace Business.DTO
{
    /// <summary>
    /// The sign up dto
    /// </summary>
    public class UserSearchParameter
    {
        //The user define login name
        public string UserName { get; set; }

        //The full name of the user
        public string FullName { get; set; }

        // The hash login password of the user
        public int RoleName { get; set; }

        // The brancode of the user assigned branch
        public string BranchCode { get; set; }

        // The mailing address of the user
        public string MailingAddress { get; set; }

        // The GPS Ghana Post Code of the user
        public string GhanaPostCode { get; set; }

        // The mobile number of the user
        public string MobileNumber { get; set; }
    }
}