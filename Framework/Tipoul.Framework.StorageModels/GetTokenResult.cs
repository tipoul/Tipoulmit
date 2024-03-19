using System;

namespace Tipoul.Framework.StorageModels
{
    public class GetTokenResult
    {
        public GetTokenResult()
        {
            CreateDate = DateTime.Now;
        }

        public int Id { get; set; }

        public string TipoulTrackNumber { get; set; }

        public string TipoulAccessToken { get; set; }
        public string TipoulAccessTokenHashed { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
