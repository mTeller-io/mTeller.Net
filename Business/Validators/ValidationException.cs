using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ValidationException : Exception
    {
        public List<ValidationFailure> Errors { get; set; }
        public ValidationException(List<ValidationFailure> errors)
        {
            Errors = errors;
        }
    }
}
