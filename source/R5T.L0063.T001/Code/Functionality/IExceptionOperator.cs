using System;

using R5T.T0132;


namespace R5T.L0063.T001
{
    [FunctionalityMarker]
    public partial interface IExceptionOperator : IFunctionalityMarker
    {
        public Exception Get_UnrecognizedSignatureType(Signature signature)
        {
            var output = new Exception($"{Instances.TypeNameOperator.Get_TypeNameOf(signature)}: unrecognized signature type.");
            return output;
        }
    }
}
