using System;


namespace R5T.L0063.F001
{
    public class SignatureStringOperator : ISignatureStringOperator
    {
        #region Infrastructure

        public static ISignatureStringOperator Instance { get; } = new SignatureStringOperator();


        private SignatureStringOperator()
        {
        }

        #endregion
    }
}


namespace R5T.L0063.F001.Platform
{
    public class SignatureStringOperator : ISignatureStringOperator
    {
        #region Infrastructure

        public static ISignatureStringOperator Instance { get; } = new SignatureStringOperator();


        private SignatureStringOperator()
        {
        }

        #endregion
    }
}
