using System;

using R5T.T0132;


namespace R5T.L0063.T001
{
    [FunctionalityMarker]
    public partial interface ITypeSignatureOperator : IFunctionalityMarker
    {
        public TypeSignature Copy(TypeSignature typeSignature)
        {
            var output = new TypeSignature
            {
                GenericTypeInputs = typeSignature.GenericTypeInputs,
                IsObsolete = typeSignature.IsObsolete,
                Is_GenericMethodParameter = typeSignature.Is_GenericMethodParameter,
                Is_GenericTypeParameter = typeSignature.Is_GenericTypeParameter,
                Is_Nested = typeSignature.Is_Nested,
                KindMarker = typeSignature.KindMarker,
                NamespaceName = typeSignature.NamespaceName,
                NestedTypeParent = typeSignature.NestedTypeParent,
                TypeName = typeSignature.TypeName,
            };

            return output;
        }

        public void Reset(TypeSignature typeSignature)
        {
            typeSignature.GenericTypeInputs = default;
            typeSignature.IsObsolete = default;
            typeSignature.Is_GenericMethodParameter = default;
            typeSignature.Is_GenericTypeParameter = default;
            typeSignature.Is_Nested = default;
            typeSignature.KindMarker = Instances.KindMarkers.Type;
            typeSignature.NamespaceName = default;
            typeSignature.NestedTypeParent = default;
            typeSignature.TypeName = default;
        }
    }
}
