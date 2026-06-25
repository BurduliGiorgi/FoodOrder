using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FoodOrder.Application.Common
{
    public class Result<T>
    {
        public bool  IsSuccess { get; set; }

        public T Value { get; set; }

        public string Error { get; set; }

        private Result(T value) { IsSuccess = true; Value = value; }
        private Result(string error) { IsSuccess = false; Error = error; }

        public static Result<T> Success(T value) => new (value);
        public static Result<T> Failure(string error) => new (error);
    }
}
