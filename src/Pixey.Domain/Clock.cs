using System;

namespace Pixey.Domain
{
    public class Clock : IClock
    {
        public DateTimeOffset GetOffsetNow()
        {
            return DateTimeOffset.UtcNow;
        }
    }
}