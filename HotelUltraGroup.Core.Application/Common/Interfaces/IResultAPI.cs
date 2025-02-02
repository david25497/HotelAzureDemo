namespace HotelUltraGroup.Core.Application.Common.Interfaces
{
    public interface IResultAPI
    {
        List<string> Messages { get; set; }
        bool Successed { get; set; }
    }

    public interface IResultAPI<out T> : IResultAPI
    {
        T Data { get; }
    }
}
