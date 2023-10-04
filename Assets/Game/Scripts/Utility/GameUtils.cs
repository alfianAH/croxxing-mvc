using System;

namespace Croxxing.Utility
{
    public static class GameUtils
    {
        public static long GetCurrentTime()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }
}