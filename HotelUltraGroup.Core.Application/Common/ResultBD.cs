using HotelUltraGroup.Core.Application.Common.Interfaces;

namespace HotelUltraGroup.Core.Application.Common
{
    public class ResultBD<T> : IResultBD<T>
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; }

        private ResultBD(bool _isSuccess, string _message, T _data = default)
        {
            IsSuccess = _isSuccess;
            Message = _message;
            Data = _data;
        }

        public static ResultBD<T> Success(T _data)
        {
            return new ResultBD<T>(true, string.Empty, _data);
        }

        public static ResultBD<T> Fail(string _message)
        {
            return new ResultBD<T>(false, _message);
        }
    }


}
