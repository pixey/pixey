using System;

namespace Pixey.Website.Caching
{
    public interface ISlidingExpirationMemoryStoreFactory
    {
        ISlidingExpirationMemoryStore<TItem> Create<TItem>(TimeSpan itemSlidingExpiration);
    }
}