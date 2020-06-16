using System.Threading.Tasks;
using Messenger.Entities.IexStock;

namespace Pricer.IexCloudProvider.IexStock
{
    public interface IIexStockProvider
    {
        Task<Option> GetOptionAsync(string symbol);
    }
}