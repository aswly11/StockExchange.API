using Microsoft.AspNetCore.SignalR;

namespace StockExchange.Hubs
{
    public class UserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Claims?.FirstOrDefault(x => x.Type == "UserId").Value;
        }
    }
}
