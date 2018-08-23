using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;

namespace ToDoList
{
    public class MetricsTracker
    {
        private readonly TelemetryClient _telemetryClient;

        public MetricsTracker( TelemetryClient telemetryClient)
        {
            this._telemetryClient = telemetryClient ?? throw new ArgumentNullException(nameof(telemetryClient));
        }

        public void Customlog()
        {
            //_telemetryClient.TrackException();
        }
    }
}
