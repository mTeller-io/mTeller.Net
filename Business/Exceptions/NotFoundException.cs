using System;

namespace Business.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException() :
            base(message: "The requested resource could not be found.")
        {
        }

        public NotFoundException(string message) :
           base(message: $"The requested resource could not be found. {message}")
        {
        }
    }
}