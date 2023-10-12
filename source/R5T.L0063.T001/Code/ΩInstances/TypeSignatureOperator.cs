using System;


namespace R5T.L0063.T001
{
    public class TypeSignatureOperator : ITypeSignatureOperator
    {
        #region Infrastructure

        public static ITypeSignatureOperator Instance { get; } = new TypeSignatureOperator();


        private TypeSignatureOperator()
        {
        }

        #endregion
    }
}
