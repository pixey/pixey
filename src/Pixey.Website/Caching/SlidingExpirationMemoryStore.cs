using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Pixey.Domain;

namespace Pixey.Website.Caching
{
    public class SlidingExpirationMemoryStore<TItem> : ISlidingExpirationMemoryStore<TItem>
    {
        private static readonly TimeSpan DefaultExpirationCheckInterval = TimeSpan.FromMinutes(1);

        private readonly Timer _timer;
        private readonly IClock _clock;
        private readonly TimeSpan _itemSlidingExpiration;
        private readonly IDictionary<string, SlidingExpirationItem> _items;

        public SlidingExpirationMemoryStore(IClock clock, TimeSpan itemSlidingExpiration)
            : this(clock, itemSlidingExpiration, DefaultExpirationCheckInterval)
        {
        }

        public SlidingExpirationMemoryStore(IClock clock, TimeSpan itemSlidingExpiration, TimeSpan expirationCheckInterval)
        {
            _clock = clock;
            _itemSlidingExpiration = itemSlidingExpiration;
            _items = new ConcurrentDictionary<string, SlidingExpirationItem>();

            _timer = new Timer(state => RemoveExpiredItems(), null, expirationCheckInterval, expirationCheckInterval);
        }

        public event EventHandler<ItemEventArgs<TItem>> RemovingExpiredItem;

        public void Add(string id, TItem item)
        {
            var expItem = new SlidingExpirationItem(item, _itemSlidingExpiration, _clock);

            _items.Add(id, expItem);
        }

        public TItem Get(string id)
        {
            var slidingExpirationItem = _items[id];

            slidingExpirationItem.ResetExpirationWindow();

            return slidingExpirationItem.Item;
        }

        public bool TryGet(string id, out TItem item)
        {
            if (_items.TryGetValue(id, out var slidingExpirationItem))
            {
                slidingExpirationItem.ResetExpirationWindow();

                item = slidingExpirationItem.Item;

                return true;
            }

            item = default;
            return false;
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        private void RemoveExpiredItems()
        {
            foreach (var key in _items.Keys)
            {
                if (_items.TryGetValue(key, out var value))
                {
                    if (value.IsExpired)
                    {
                        if (RemovingExpiredItem != null)
                        {
                            var args = new ItemEventArgs<TItem>(value.Item);

                            RemovingExpiredItem(this, args);
                        }

                        _items.Remove(key);
                    }
                }
            }
        }

        private class SlidingExpirationItem
        {
            private DateTimeOffset _lastAccessed;

            private readonly TimeSpan _slidingExpiration;
            private readonly IClock _clock;

            public SlidingExpirationItem(TItem item, TimeSpan slidingExpiration, IClock clock)
            {
                _slidingExpiration = slidingExpiration;
                _clock = clock;

                Item = item;

                _lastAccessed = _clock.GetOffsetNow();
            }

            public TItem Item { get; }

            public bool IsExpired
            {
                get => (_clock.GetOffsetNow() - _lastAccessed) >= _slidingExpiration;
            }

            public void ResetExpirationWindow()
            {
                _lastAccessed = _clock.GetOffsetNow();
            }
        }
    }
}