using HotelUltraGroup.Core.Application.Common.Interfaces;

namespace HotelUltraGroup.Core.Application.Common
{
    /// <summary>
    /// El siguiente modelo de datos se utiliza para retornar el resultado de forma generica.
    /// </summary>
    public class ResultAPI : IResultAPI
    {
        public bool Successed { get; set; }

        //public bool Failed => !Successed;

        public List<string> Messages { get; set; } = new List<string>();

        public static IResultAPI Fail()
        {
            return new ResultAPI { Successed = false };
        }

        public static IResultAPI Fail(string Message)
        {
            return new ResultAPI { Successed = false, Messages = new List<string> { Message } };
        }

        public static IResultAPI Fail(List<string> Messages)
        {
            return new ResultAPI { Successed = false, Messages = Messages };
        }

        public static IResultAPI Success()
        {
            return new ResultAPI { Successed = true };
        }

        public static IResultAPI Success(string Message)
        {
            return new ResultAPI { Successed = true, Messages = new List<string> { Message } };
        }

        public static IResultAPI Success(List<string> Messages)
        {
            return new ResultAPI { Successed = true, Messages = Messages };
        }
    }

    public class ResultAPI<T> : ResultAPI, IResultAPI<T>
    {
        public T Data { get; set; }

        #region SIN DATA
        public static new ResultAPI<T> Fail()
        {
            return new ResultAPI<T> { Successed = false };
        }

        public static new ResultAPI<T> Fail(string Message)
        {
            return new ResultAPI<T> { Successed = false, Messages = new List<string> { Message } };
        }

        public static new ResultAPI<T> Fail(List<string> Messages)
        {
            return new ResultAPI<T> { Successed = false, Messages = Messages };
        }

        public static new ResultAPI<T> Success()
        {
            return new ResultAPI<T> { Successed = true };
        }

        public static new ResultAPI<T> Success(string Message)
        {
            return new ResultAPI<T> { Successed = true, Messages = new List<string> { Message } };
        }

        public static new ResultAPI<T> Success(List<string> Messages)
        {
            return new ResultAPI<T> { Successed = true, Messages = Messages };
        }
        #endregion

        #region CON DATA
        public static ResultAPI<T> Fail(T Data)
        {
            return new ResultAPI<T> { Successed = false, Data = Data };
        }

        public static ResultAPI<T> Fail(string Message, T Data)
        {
            return new ResultAPI<T> { Successed = false, Messages = new List<string> { Message }, Data = Data };
        }

        public static ResultAPI<T> Fail(List<string> Messages, T Data)
        {
            return new ResultAPI<T> { Successed = false, Messages = Messages, Data = Data };
        }

        public static ResultAPI<T> Success(T Data)
        {
            return new ResultAPI<T> { Successed = true, Data = Data };
        }

        public static ResultAPI<T> Success(string Message, T Data)
        {
            return new ResultAPI<T> { Successed = true, Messages = new List<string> { Message }, Data = Data };
        }

        public static ResultAPI<T> Success(List<string> Messages, T Data)
        {
            return new ResultAPI<T> { Successed = true, Messages = Messages, Data = Data };
        }
        #endregion
    }

}
