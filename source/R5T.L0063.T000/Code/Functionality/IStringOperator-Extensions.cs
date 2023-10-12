using System;

using R5T.T0132;


namespace R5T.L0063.T000.Extensions
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="ISignatureString"/>
        public ISignatureString ToSignatureString(string value)
        {
            var output = new SignatureString(value);
            return output;
        }
    }
}
