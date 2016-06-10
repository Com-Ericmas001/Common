using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Ericmas001.Common
{
    public class EventArgs<T> : EventArgs
    {
        public T Info { get; private set; }

        public EventArgs(T info)
        {
            Info = info;
        }
    }
}
