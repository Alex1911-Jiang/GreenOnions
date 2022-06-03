using System.Collections;

namespace GreenOnions.Interface
{
    public interface IGreenOnionsMessages :IList
    {
        public bool Reply { get; set; }

        public int RevokeTime { get; set; }

        public long SenderId { get; set; }
        public string SenderName { get; set; }
    }
}
