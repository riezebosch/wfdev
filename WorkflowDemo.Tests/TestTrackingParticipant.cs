using System;
using System.Activities.Tracking;
using System.Collections.Generic;

namespace WorkflowDemo.Tests
{
    internal class TestTrackingParticipant 
        : TrackingParticipant
    {
        public bool IsInvoked { get; internal set; }

        public IList<TrackingRecord> Records { get; } = new List<TrackingRecord>();

        protected override void Track(TrackingRecord record, TimeSpan timeout)
        {
            Records.Add(record);
            IsInvoked = true;
        }
    }
}