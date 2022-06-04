namespace Business.DTO
{
    /// <summary>
    /// The sign in DTO class
    /// </summary>
    public class UserSignIn
    {
        //User registered email same as signin username
        public string UserName { get; set; }

        //User sign passwrd
        public string Password { get; set; }
    }
}