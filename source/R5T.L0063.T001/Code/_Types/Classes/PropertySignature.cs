using System;

using R5T.T0142;


namespace R5T.L0063.T001
{
    [DataTypeMarker]
    public class PropertySignature : Signature
    {
        public TypeSignature DeclaringType { get; set; }
        public string PropertyName { get; set; }
        public TypeSignature Type { get; set; }

        /// <summary>
        /// If the property is an indexer, it will have input parameters.
        /// </summary>
        public MethodParameter[] Parameters { get; set; }


        public PropertySignature()
        {
            this.KindMarker = Instances.KindMarkers.Property;
        }
    }
}
