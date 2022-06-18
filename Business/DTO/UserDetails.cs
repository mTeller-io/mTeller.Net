namespace Business.DTO
{
    /// <summary>
    /// The sign up dto
    /// </summary>
    public class UserDetail
    {
        //The user define login name
        public string UserName { get; set; }

        //The full name of the user
        public string FullName { get; set; }

        // The id of the user assigned role from the roles object
        public int RoleID { get; set; }

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