using System;

namespace Business.Exceptions
{
    [Serializable]
    public class ForbiddenException : Exception
    {
        public ForbiddenException(Exception innerException) :
            base(message: $"An internal server error occured, please contact Admin.\n\n", innerException)
        {
        }

        public ForbiddenException(string message) :
          base(message: $"An internal server error occured, please contact Admin. {message}")
        {
        }
    }
}