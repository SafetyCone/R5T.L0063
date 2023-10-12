using System;


namespace R5T.L0063.F002
{
    public static class Instances
    {
        public static IExceptionOperator ExceptionOperator => F002.ExceptionOperator.Instance;
        public static L0053.IIndices Indices => L0053.Indices.Instance;
        public static L0053.IStringOperator StringOperator => L0053.StringOperator.Instance;
        public static Z000.ITokenSeparators TokenSeparators => Z000.TokenSeparators.Instance;
        public static Z000.ITypeNameAffixes TypeNameAffixes => Z000.TypeNameAffixes.Instance;
        public static T001.ITypeSignatureOperator TypeSignatureOperator => T001.TypeSignatureOperator.Instance;
    }
}