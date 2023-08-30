using System;

namespace ExceptionDemo
{
    /*
     * Programs can throw a predefined exception class in the System namespace (except where previously noted), 
     * or create their own exception classes by deriving from Exception. The derived classes should define at 
     * least three constructors: one parameterless constructor, one that sets the message property, and one that 
     * sets both the Message and InnerException properties.
     * 
     * Add new properties to the exception class when the data they provide is useful to resolving the exception. 
     * If new properties are added to the derived exception class, ToString() should be overridden to return 
     * the added information.
     */
    class CustomException : Exception
    {
        // calls parent constructor via base first with : base() or base(...)
        public CustomException() : base() { }
        public CustomException(string message) : base(message) { }
        public CustomException(string message, Exception inner) : base(message, inner) { }
    }
}