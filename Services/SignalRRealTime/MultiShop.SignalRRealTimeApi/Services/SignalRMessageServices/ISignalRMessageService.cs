namespace MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetMessageCountByReceiverId(string token,string recevierId);
    }
}
