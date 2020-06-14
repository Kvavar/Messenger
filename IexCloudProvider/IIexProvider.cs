using System.Collections.Generic;
using System.Threading.Tasks;
using Messenger.Entities.IexPricer;

namespace Pricer.IexCloudProvider
{
    public interface IIexProvider
    {
        Task<IReadOnlyList<TimeseriesId>> GetAvailableIdsAsync();
    }
}