using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT365Assignment1
{
    public static class EventFactory
    {
        public enum EventType
        {
            Facbook,
            Twitter,
            Photo,
            Video,
            TrackLog
        }
        
        public static Event CreateEvent (EventType e)
        {
            switch (e)
            {
                case EventType.Facbook:
                    return new FacebookEvent();
                case EventType.Twitter:
                    return new TwitterEvent();
                case EventType.Photo:
                    return new PhotoEvent();
                case EventType.Video:
                    return new VideoEvent();
                case EventType.TrackLog:
                    return new TrackLogEvent();
                default:
                    return null;
            }
        }
    }
}
