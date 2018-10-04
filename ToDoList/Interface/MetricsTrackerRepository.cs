using System;
using Microsoft.ApplicationInsights;

namespace ToDoList.Interface
{
    public class MetricsTrackerRepository : IMetricsTrackerRepository
    {
        private readonly TelemetryClient telemetryClient;

        public MetricsTrackerRepository(TelemetryClient telemetryClient)
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
