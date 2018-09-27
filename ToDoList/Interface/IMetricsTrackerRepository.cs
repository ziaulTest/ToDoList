using System;

namespace ToDoList.Interface
{
    public interface IMetricsTrackerRepository
    {
        void EventTracker(string str);

        void LogException(Exception ex);

        void TrackTrace(string str);
    }
}
