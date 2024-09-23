using System;


namespace R5T.L0063.F000
{
    public static class Instances
    {
        public static L0066.IArrayOperator ArrayOperator => L0066.ArrayOperator.Instance;
        public static L0066.IEnumerableOperator EnumerableOperator => L0066.EnumerableOperator.Instance;
        public static L0066.IIndexOperator IndexOperator => L0066.IndexOperator.Instance;
        public static L0066.IIndices Indices => L0066.Indices.Instance;
        public static L0062.L001.IKindMarkerOperator KindMarkerOperator => L0062.L001.KindMarkerOperator.Instance;
        public static IMemberNameOperator MemberNameOperator => F000.MemberNameOperator.Instance;
        public static L0066.IRangeOperator RangeOperator => L0066.RangeOperator.Instance;
        public static L0053.IStringOperator StringOperator => L0053.StringOperator.Instance;
        public static Extensions.IStringOperator StringOperator_Extensions => Extensions.StringOperator.Instance;
        public static Z000.ITokens Tokens => Z000.Tokens.Instance;
        public static Z000.ITokenSeparators TokenSeparators => Z000.TokenSeparators.Instance;
        public static ITypeNameAffixes TypeNameAffixes => F000.TypeNameAffixes.Instance;
        public static L0066.ITypeNameAffixSets TypeNameAffixSets => L0066.TypeNameAffixSets.Instance;
    }
}