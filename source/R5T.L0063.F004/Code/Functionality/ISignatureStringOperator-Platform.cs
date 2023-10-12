using System;

using R5T.T0132;

using R5T.L0063.T001;


namespace R5T.L0063.F004.Platform
{
    [FunctionalityMarker]
    public partial interface ISignatureStringOperator : IFunctionalityMarker,
        F000.ISignatureStringOperator
    {
        //public string Get_SignatureString(Signature signature)
        //{
        //    var output = Instances.SignatureOperator.Get_SignatureString(signature);
        //    return output;
        //}
    }
}
