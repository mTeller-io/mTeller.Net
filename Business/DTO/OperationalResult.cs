using System;
using System.Collections.Generic;

namespace Business.DTO
{
    public class OperationalResult
    {
        public bool Status {get;set;}
        public string Message {get;set;}
        public List<object> Data {get;set;}
        public List<Error> ErrorCode {get;set;}
    }

    public class Error{
        public string ErrorCode {get;set;}
        public string ErrorMessage {get;set;}
    }
}