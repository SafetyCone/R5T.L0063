using System;
using System.Reflection;

using R5T.T0132;

using R5T.L0063.T000;


namespace R5T.L0063.F001
{
    [FunctionalityMarker]
    public partial interface ISignatureStringOperator : IFunctionalityMarker,
        F000.ISignatureStringOperator
    {
#pragma warning disable IDE1006 // Naming Styles
        public Platform.ISignatureStringOperator _Platform => Platform.SignatureStringOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public ISignatureString Get_SignatureString(MemberInfo memberInfo)
        {
            return Instances.MemberInfoOperator.Get_SignatureString(memberInfo);
        }
    }
}
