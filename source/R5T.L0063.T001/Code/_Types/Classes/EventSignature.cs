using System;

using R5T.T0142;


namespace R5T.L0063.T001
{
    [DataTypeMarker]
    public class EventSignature : Signature
    {
        public TypeSignature DeclaringType { get; set; }
        public string EventName { get; set; }
        public TypeSignature EventHandlerType { get; set; }


        public EventSignature()
        {
            this.KindMarker = Instances.KindMarkers.Event;
        }
    }
}
