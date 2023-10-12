using System;

using R5T.T0131;


namespace R5T.L0063.Z000
{
    [ValuesMarker]
    public partial interface ITokens : IValuesMarker
    {
        /// <summary>
        /// <para>" [Obsolete]", a space, then the obsolete attribute.</para>
        /// Note that the space is essential, since all obsolete signature strings will need to separate from any array output types.
        /// </summary>
        public string ObsoleteToken => " [Obsolete]";
    }
}
