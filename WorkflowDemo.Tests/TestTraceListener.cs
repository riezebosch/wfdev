using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WorkflowDemo.Tests
{
    internal class TestTraceListener : TraceListener
    {
        public IList<object> Messages { get; } = new List<object>();

        public override void Write(string message)
        {
            Messages.Add(message);
        }

        public override void WriteLine(string message)
        {
            Messages.Add(message);
        }

        public override void Write(object o)
        {
            Messages.Add(o);
        }

        public override void WriteLine(object o)
        {
            Messages.Add(o);
        }

        public override void Write(object o, string category)
        {
            Messages.Add(o);
        }

        public override void Write(string message, string category)
        {
            Messages.Add(message);
        }

        public override void WriteLine(object o, string category)
        {
            Messages.Add(o);
        }

        public override void WriteLine(string message, string category)
        {
            Messages.Add(message);
        }

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            Messages.Add(data);
        }

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, params object[] data)
        {
            Messages.Add(data);
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id)
        {
            Messages.Add(source);
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            Messages.Add(string.Format(format, args));
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            Messages.Add(message);
        }

        public override void TraceTransfer(TraceEventCache eventCache, string source, int id, string message, Guid relatedActivityId)
        {
            Messages.Add(message);
        }
    }
}