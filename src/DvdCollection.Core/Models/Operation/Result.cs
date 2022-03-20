using System;

namespace DvdCollection.Core.Models.Operation
{
    public class Result<T>
    {
        public T Value { get; }
        public string Message { get; }
        public bool IsSuccess { get; }
        public Exception Exception { get; }

        public Result(T value, string message = null)
        {
            IsSuccess = true;
            Value = value;
            Message = message;
        }

        public Result(Exception exception, string message = null)
        {
            Exception = exception;
            Message = message ?? exception.Message;
        }

        public Result(string message)
        {
            Message = message;
        }

    }
}
