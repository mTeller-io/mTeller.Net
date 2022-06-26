using System;

namespace Business.Exceptions
{
    [Serializable]
    public class NotAuthenticatedException : Exception
    {
        public NotAuthenticatedException() :
            base(message: "User does not have rights or not properly authenticated.")
        {
        }
    }
}