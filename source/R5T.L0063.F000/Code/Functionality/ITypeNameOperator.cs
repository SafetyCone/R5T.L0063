using System;

using R5T.T0132;


namespace R5T.L0063.F000
{
    [FunctionalityMarker]
    public partial interface ITypeNameOperator : IFunctionalityMarker
    {
        public string Get_GenericTypeParameterMarkedTypeName(string genericTypeParameterName)
        {
            var output = $"{Instances.TypeNameAffixes.TypeParameterMarker_Prefix}{genericTypeParameterName}";
            return output;
        }

        public string Get_GenericMethodParameterMarkedTypeName(string genericTypeParameterName)
        {
            var output = $"{Instances.TypeNameAffixes.MethodTypeParameterMarker_Prefix}{genericTypeParameterName}";
            return output;
        }
    }
}
