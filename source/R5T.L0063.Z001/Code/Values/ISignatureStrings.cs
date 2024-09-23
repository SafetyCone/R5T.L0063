using System;

using R5T.T0131;
using R5T.T0143;


namespace R5T.L0063.Z001
{
    [ValuesMarker]
    public partial interface ISignatureStrings : IValuesMarker
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Raw.ISignatureStrings _Raw => Raw.SignatureStrings.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}
