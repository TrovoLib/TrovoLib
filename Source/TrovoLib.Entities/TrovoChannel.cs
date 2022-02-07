namespace TrovoLib.Entities
{
    public class TrovoChannel
    {
        public int ChannelID { get; set; }

        public int StreamerUserID { get; set; }

        public string ChannelUrl { get; set; }

        public bool IsLive { get; set; }
    }
}
