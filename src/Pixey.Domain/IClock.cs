using System;

namespace Pixey.Domain
{
    public interface IClock
    {
        DateTimeOffset GetOffsetNow();
    }
}