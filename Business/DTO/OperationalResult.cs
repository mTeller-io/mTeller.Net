using System.Collections.Generic;

namespace Business.DTO
{
    public class OperationalResult<T> where T : class
    {
        //True or False status of operation
        public bool Status { get; set; }

        //Single messsage from operation
        public string Message { get; set; }

        //The bearer token
        public string AuthToken { get; set; }

        //Result of successfully operation

        public T Data { get; set; }

        //error list of failed operation
        public List<Error> ErrorList { get; set; } = new List<Error>();
    }

    public class Error
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}