using System;

namespace VerseFlow.GFramework.Events
{
    [Flags]
    public enum EventResult
    {
        Unspecified = 0,
        Cancel = 1,
        Process = Cancel << 1,
    }
}
