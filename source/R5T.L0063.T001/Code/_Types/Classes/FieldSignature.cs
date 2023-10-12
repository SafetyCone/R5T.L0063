using System;

using R5T.T0142;


namespace R5T.L0063.T001
{
    [DataTypeMarker]
    public class FieldSignature : Signature
    {
        public TypeSignature DeclaringType { get; set; }
        public string FieldName { get; set; }
        public TypeSignature Type { get; set; }


        public FieldSignature()
        {
            this.KindMarker = Instances.KindMarkers.Field;
        }
    }
}
