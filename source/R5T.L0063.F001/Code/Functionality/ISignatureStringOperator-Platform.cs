using System;
using System.Reflection;

using R5T.T0132;


namespace R5T.L0063.F001.Platform
{
    [FunctionalityMarker]
    public partial interface ISignatureStringOperator : IFunctionalityMarker,
        F000.ISignatureStringOperator
    {
        public string Get_SignatureString(MemberInfo memberInfo)
        {
            var output = Instances.MemberInfoOperator._Platform.Get_SignatureString(memberInfo);
            return output;
        }
    }
}
