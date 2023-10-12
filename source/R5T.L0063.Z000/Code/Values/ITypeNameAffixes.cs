using System;

using R5T.T0131;


namespace R5T.L0063.Z000
{
    /// <summary>
    /// For signature strings.
    /// </summary>
    [ValuesMarker]
    public partial interface ITypeNameAffixes : IValuesMarker
    {
        /// <summary>
        /// <para><name>"``" (two back-ticks)</name></para>
        /// </summary>
        public const string MethodTypeParameterMarker_Prefix_Constant = "``";

        /// <inheritdoc cref="MethodTypeParameterMarker_Prefix_Constant"/>
        public string MethodTypeParameterMarker_Prefix => MethodTypeParameterMarker_Prefix_Constant;

        /// <summary>
        /// <para><name>'`' (back-tick)</name></para>
        /// </summary>
        public const char TypeParameterMarker_Prefix_Constant = '`';

        /// <inheritdoc cref="TypeParameterMarker_Prefix_Constant"/>
        public char TypeParameterMarker_Prefix => TypeParameterMarker_Prefix_Constant;
    }
}
