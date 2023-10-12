using System;


namespace R5T.L0063.F001
{
    public class TypeNameOperator : ITypeNameOperator
    {
        #region Infrastructure

        public static ITypeNameOperator Instance { get; } = new TypeNameOperator();


        private TypeNameOperator()
        {
        }

        #endregion
    }
}
