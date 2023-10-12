using System;


namespace R5T.L0063.T000.Extensions
{
    public static class StringExtensions
    {
        /// <inheritdoc cref="IStringOperator.ToSignatureString(string)"/>
        public static ISignatureString ToSignatureString(this string value)
        {
            return Instances.StringOperator_Extensions.ToSignatureString(value);
        }
    }
}
