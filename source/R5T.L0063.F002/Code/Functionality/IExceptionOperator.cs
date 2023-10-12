using System;

using R5T.T0132;


namespace R5T.L0063.F002
{
    [FunctionalityMarker]
    public partial interface IExceptionOperator : IFunctionalityMarker,
        L0062.L001.IExceptionOperator
    {
        public Exception Get_ErrorSignatureDoesNotExistException()
        {
            return new Exception("There are no error signature strings.");
        }

        public Exception Get_NamespaceSignatureDoesNotExistException()
        {
            return new Exception("There are no namespace signature strings.");
        }
    }
}
