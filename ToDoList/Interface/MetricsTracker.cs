using System;
using Microsoft.ApplicationInsights;

namespace ToDoList.Interface
{
    public class MetricsTracker : IMetricsTrackerRepository
    {
        private readonly TelemetryClient telemetryClient;

        public MetricsTracker(TelemetryClient telemetryClient)
        {
            this.telemetryClient = telemetryClient ?? throw new ArgumentNullException(nameof(telemetryClient));
        }

        public void EventTracker(string str)
        {

            telemetryClient.TrackEvent("");
        }

        public void LogException(Exception ex)
        {
            telemetryClient.TrackException(ex);
        }

        public void TrackTrace(string str)
        {
            telemetryClient.TrackTrace("");
        }

    }
}
