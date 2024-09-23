using System;

using R5T.T0132;


namespace R5T.L0063.F000
{
    [FunctionalityMarker]
    public partial interface ITypeNameOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Prefixes the <see cref="Z000.ITypeNameAffixes.TypeParameterMarker_Prefix"/> (<inheritdoc cref="Z000.ITypeNameAffixes.TypeParameterMarker_Prefix" path="descendant::name"/>) to the generic type parameter name.
        /// </summary>
        public string Get_GenericTypeParameterMarkedTypeName(string genericTypeParameterName)
        {
            var output = $"{Instances.TypeNameAffixes.TypeParameterMarker_Prefix}{genericTypeParameterName}";
            return output;
        }

        /// <summary>
        /// Prefixes the <see cref="Z000.ITypeNameAffixes.MethodTypeParameterMarker_Prefix"/> (<inheritdoc cref="Z000.ITypeNameAffixes.MethodTypeParameterMarker_Prefix" path="descendant::name"/>) to the generic type parameter name.
        /// </summary>
        public string Get_GenericMethodParameterMarkedTypeName(string genericTypeParameterName)
        {
            var output = $"{Instances.TypeNameAffixes.MethodTypeParameterMarker_Prefix}{genericTypeParameterName}";
            return output;
        }
    }
}
