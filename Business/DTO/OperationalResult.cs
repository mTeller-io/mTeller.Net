using System;
using System.Collections.Generic;

namespace Business.DTO
{
    public class OperationalResult
    {
        //True or False status of operation
        public bool Status {get;set;}
        //Single messsage from operation
        public string Message {get;set;}
        //The bearer token
        public string AuthToken {get;set;}
        //Result of successfully operation
        public List<object> Data {get;set;}
        //error list of failed operation
        public List<Error> ErrorList {get;set;}
    }

    public class Error{
        public string ErrorCode {get;set;}
        public string ErrorMessage {get;set;}
    }
}