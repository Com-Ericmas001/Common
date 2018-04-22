using System;

namespace Com.Ericmas001.Common
{
    public class EventArgs<T> : EventArgs
    {
        public T Info { get; }

        public EventArgs(T info)
        {
            Info = info;
        }
    }
}
