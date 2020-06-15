using System.Threading.Tasks;
using Messenger.Entities.IexReferenceData;

namespace Pricer.IexCloudProvider.IexReferenceData
{
    public interface IIexReferenceDataProvider
    {
        Task<FxSymbolsContainer> GetAvailableFxSymbolsAsync();
    }
}