using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pricer.IexCloudProvider.IexStock
{
    public interface IIexOptionProvider
    {
        Task<IReadOnlyList<DateTime>> GetAvailableExpirationsAsync(string symbol);
    }
}