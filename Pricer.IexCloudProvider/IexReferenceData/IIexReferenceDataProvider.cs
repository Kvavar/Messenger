using System.Collections.Generic;
using System.Threading.Tasks;
using Messenger.Entities.IexReferenceData;

namespace Pricer.IexCloudProvider.IexReferenceData
{
    public interface IIexReferenceDataProvider
    {
        Task<FxSymbolsContainer> GetAvailableFxSymbolsAsync();
        Task<IReadOnlyList<IexSymbol>> GetAvailableIexSymbolsAsync();
    }
}