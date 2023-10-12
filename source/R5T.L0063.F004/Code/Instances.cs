using System;


namespace R5T.L0063.F004
{
    public static class Instances
    {
        public static L0053.IArrayOperator ArrayOperator => L0053.ArrayOperator.Instance;
        public static T001.IExceptionOperator ExceptionOperator => T001.ExceptionOperator.Instance;
        public static ISignatureOperator SignatureOperator => F004.SignatureOperator.Instance;
        public static ISignatureStringOperator SignatureStringOperator => F004.SignatureStringOperator.Instance;
        public static Z0000.IStrings Strings => Z0000.Strings.Instance;
        public static Z000.ITokenSeparators TokenSeparators => Z000.TokenSeparators.Instance;
        public static Z000.ITypeNameAffixes TypeNameAffixes => Z000.TypeNameAffixes.Instance;
    }
}