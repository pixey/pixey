using System;

namespace Pixey.Website.Caching
{
    public class ItemEventArgs<TItem> : EventArgs
    {
        public TItem Item { get; }

        public ItemEventArgs(TItem item)
        {
            Item = item;
        }
    }
}