using System;


namespace R5T.L0063.F001
{
    public static class Instances
    {
        public static L0053.IEventInfoOperator EventInfoOperator => L0053.EventInfoOperator.Instance;
        public static IExceptionOperator ExceptionOperator => F001.ExceptionOperator.Instance;
        public static L0062.L001.IKindMarkerOperator KindMarkerOperator => L0062.L001.KindMarkerOperator.Instance;
        public static IMemberInfoOperator MemberInfoOperator => F001.MemberInfoOperator.Instance;
        public static L0053.IMethodBaseOperator MethodBaseOperator => L0053.MethodBaseOperator.Instance;
        public static L0053.IMethodInfoOperator MethodInfoOperator => L0053.MethodInfoOperator.Instance;
        public static L0053.INamespacedTypeNameOperator NamespacedTypeNameOperator => L0053.NamespacedTypeNameOperator.Instance;
        public static IParameterInfoOperator ParameterInfoOperator => F001.ParameterInfoOperator.Instance;
        public static L0053.IPropertyInfoOperator PropertyInfoOperator => L0053.PropertyInfoOperator.Instance;
        public static ISignatureStringOperator SignatureStringOperator => F001.SignatureStringOperator.Instance;
        public static L0053.IStringOperator StringOperator => L0053.StringOperator.Instance;
        public static Z000.ITokens Tokens => Z000.Tokens.Instance;
        public static Z000.ITokenSeparators TokenSeparators => Z000.TokenSeparators.Instance;
        public static ITypeNameOperator TypeNameOperator => F001.TypeNameOperator.Instance;
        public static ITypeOperator TypeOperator => F001.TypeOperator.Instance;
    }
}