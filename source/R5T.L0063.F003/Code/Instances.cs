using System;


namespace R5T.L0063.F003
{
    public static class Instances
    {
        public static L0053.IArrayOperator ArrayOperator => L0053.ArrayOperator.Instance;
        public static T001.IExceptionOperator ExceptionOperator => T001.ExceptionOperator.Instance;
        public static L0062.F000.IIdentityStringOperator IdentityStringOperator => L0062.F000.IdentityStringOperator.Instance;
        public static F000.ISignatureStringOperator SignatureStringOperator => F000.SignatureStringOperator.Instance;
        public static L0062.Z000.ITokenSeparators TokenSeparators_IdentityString => L0062.Z000.TokenSeparators.Instance;
        public static L0053.ITypeNameOperator TypeNameOperator => L0053.TypeNameOperator.Instance;
    }
}