using System;


namespace R5T.L0063.Z000
{
    public class KindMarkers : IKindMarkers
    {
        #region Infrastructure

        public static IKindMarkers Instance { get; } = new KindMarkers();


        private KindMarkers()
        {
        }

        #endregion
    }
}
