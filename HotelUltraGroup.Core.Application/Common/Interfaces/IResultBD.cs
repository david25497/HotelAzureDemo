namespace HotelUltraGroup.Core.Application.Common.Interfaces
{
    public interface IResultBD<T>
    {
        bool IsSuccess { get; }
        string Message { get; }
        T Data { get; }
    }

}
