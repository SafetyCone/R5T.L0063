using System;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0063.F001
{
    [FunctionalityMarker]
    public partial interface IParameterInfoOperator : IFunctionalityMarker,
        L0053.IParameterInfoOperator
    {
        public string Get_NamespacedTypeName_OfParameterType(ParameterInfo parameterInfo)
        {
            var parameterType = this.Get_ParameterType(parameterInfo);

            var parameterTypeNamespacedTypeName = Instances.TypeOperator.Get_NamespacedTypeName(parameterType);
            return parameterTypeNamespacedTypeName;
        }
    }
}
