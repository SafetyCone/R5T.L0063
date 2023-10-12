using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.L0063.T000
{
    /// <summary>
    /// Strongly-types a string as a .NET member signature string.
    /// </summary>
    /// <remarks>
    /// Signature strings build on identity strings.
    /// Identity strings uniquely identity a .NET member, but lack some information about the member (for example, the return types of methods).
    /// Signature strings strive to be exactly what their name suggests: the signature of the member they represent.
    /// A signature string is best thought of as what the signature of a member would look like; for a method it would contain the input parameter names, as well as the output type.
    /// But beyond just the signature of the member, for methods as an example, it would also contain the namespaced type name of the declaring type for the method.
    /// </remarks>
    [StrongTypeMarker]
    public interface ISignatureString : IStrongTypeMarker,
        ITyped<string>
    {
    }
}