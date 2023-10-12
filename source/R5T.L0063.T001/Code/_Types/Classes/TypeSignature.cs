using System;

using R5T.T0142;


namespace R5T.L0063.T001
{
    [DataTypeMarker]
    public class TypeSignature : Signature
    {
        public string NamespaceName { get; set; }

        /// <summary>
        /// The simple type name.
        /// </summary>
        public string TypeName { get; set; }

        public bool Is_Nested { get; set; }

        /// <summary>
        /// For nested types, this is the parent type signature string.
        /// </summary>
        public TypeSignature NestedTypeParent { get; set; }

        /// <summary>
        /// Generic type inputs are either 1) parameters or 2) arguments.
        /// If the method is a generic method definition (open generic method without specified generic type arguments), then it will have generic type parameter names.
        /// If the method is a constructed generic method (closed generic method with specified generic type arguments), then it will have generic type arguments.
        /// </summary>
        public TypeSignature[] GenericTypeInputs { get; set; }

        public bool Is_GenericMethodParameter { get; set; }
        public bool Is_GenericTypeParameter { get; set; }

        public bool Has_ElementType { get; set; }

        public TypeSignature ElementType { get; set; }


        public TypeSignature()
        {
            this.KindMarker = Instances.KindMarkers.Type;
        }
    }
}
