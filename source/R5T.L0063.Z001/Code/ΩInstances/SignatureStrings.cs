using System;


namespace R5T.L0063.Z001
{
    public class SignatureStrings : ISignatureStrings
    {
        #region Infrastructure

        public static ISignatureStrings Instance { get; } = new SignatureStrings();


        private SignatureStrings()
        {
        }

        #endregion
    }
}


namespace R5T.L0063.Z001.Platform
{
    public class SignatureStrings : ISignatureStrings
    {
        #region Infrastructure

        public static ISignatureStrings Instance { get; } = new SignatureStrings();


        private SignatureStrings()
        {
        }

        #endregion
    }
}


namespace R5T.L0063.Z001.Platform.Raw
{
    public class SignatureStrings : ISignatureStrings
    {
        #region Infrastructure

        public static ISignatureStrings Instance { get; } = new SignatureStrings();


        private SignatureStrings()
        {
        }

        #endregion
    }
}


namespace R5T.L0063.Z001.Raw
{
    public class SignatureStrings : ISignatureStrings
    {
        #region Infrastructure

        public static ISignatureStrings Instance { get; } = new SignatureStrings();


        private SignatureStrings()
        {
        }

        #endregion
    }
}
