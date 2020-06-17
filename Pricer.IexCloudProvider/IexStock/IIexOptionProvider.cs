using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Messenger.Entities.IexStock;

namespace Pricer.IexCloudProvider.IexStock
{
    public interface IIexOptionProvider
    {
        Task<IReadOnlyList<DateTime>> GetAvailableExpirationsAsync(string symbol);
        Task<IReadOnlyList<Option>> GetOptionAsync(string symbol, DateTime expiration, OptionSide side);
    }
}