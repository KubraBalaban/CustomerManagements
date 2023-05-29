using System.Net;

namespace CustomerManagementAPI.App.Helper.Interface
{
    public interface ISecurityTokenHandler
    {
        Task<string> GetToken();
        Task<int> CheckTokenExpTime(string token);
        Task CheckUnauthorizeStatus(HttpStatusCode httpStatusCode);
        Task<string> GenerateToken(string username, int expireMinutes = 20);
    }
}
