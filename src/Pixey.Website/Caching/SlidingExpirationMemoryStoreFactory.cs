using System;
using Pixey.Domain;

namespace Pixey.Website.Caching
{
    public class SlidingExpirationMemoryStoreFactory : ISlidingExpirationMemoryStoreFactory
    {
        private readonly IClock _clock;

        public SlidingExpirationMemoryStoreFactory(IClock clock)
        {
            _clock = clock;
        }

        public ISlidingExpirationMemoryStore<TItem> Create<TItem>(TimeSpan itemSlidingExpiration)
        {
            return new SlidingExpirationMemoryStore<TItem>(_clock, itemSlidingExpiration);
        }
    }
}