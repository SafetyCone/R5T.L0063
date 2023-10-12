using System;

using R5T.T0132;

using R5T.L0063.T000;
using R5T.L0063.T001;


namespace R5T.L0063.F004
{
    [FunctionalityMarker]
    public partial interface ISignatureStringOperator : IFunctionalityMarker,
        F000.ISignatureStringOperator
    {
#pragma warning disable IDE1006 // Naming Styles
        public Platform.ISignatureStringOperator _Platform => Platform.SignatureStringOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public ISignatureString Get_SignatureString(Signature signature)
        {
            var output = Instances.SignatureOperator.Get_SignatureString(signature);
            return output;
        }
    }
}
