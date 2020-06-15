using System.Threading.Tasks;

namespace Pricer.IexCloudProvider
{
    public interface IIexHttpClient
    {
        //todo add cancellation
        Task<string> GetAsync(string url);
    }
}