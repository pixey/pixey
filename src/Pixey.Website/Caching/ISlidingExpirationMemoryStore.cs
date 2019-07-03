using System;

namespace Pixey.Website.Caching
{
    public interface ISlidingExpirationMemoryStore<TItem> : IDisposable
    {
        event EventHandler<ItemEventArgs<TItem>> RemovingExpiredItem;

        void Add(string id, TItem item);

        TItem Get(string id);

        bool TryGet(string id, out TItem item);
    }
}