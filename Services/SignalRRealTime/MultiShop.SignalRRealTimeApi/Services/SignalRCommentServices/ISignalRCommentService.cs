﻿namespace MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices
{
    public interface ISignalRCommentService
    {
        Task<int> GetCommentCount(string token);
    }
}
