﻿namespace GreenOnions.Model
{
    public class GreenOnionsAtMessage : GreenOnionsBaseMessage
    {
        public long AtId { get; set; }
        public string NickName { get; set; }
        public GreenOnionsAtMessage(long atId, string nickName)
        {
            AtId = atId;
            NickName = nickName;
        }
    }
}
