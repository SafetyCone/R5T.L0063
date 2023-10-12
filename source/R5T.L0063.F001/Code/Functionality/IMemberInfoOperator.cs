using System;
using System.Reflection;

using R5T.T0132;

using R5T.L0063.T000;
using R5T.L0063.T000.Extensions;


namespace R5T.L0063.F001
{
    /// <summary>
    /// Operations for getting signature strings.
    /// </summary>
    [FunctionalityMarker]
    public partial interface IMemberInfoOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Platform.IMemberInfoOperator _Platform => Platform.MemberInfoOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public ISignatureString Get_SignatureString(MemberInfo memberInfo)
        {
            var output = _Platform.Get_SignatureString(memberInfo)
                .ToSignatureString();

            return output;
        }
    }
}
