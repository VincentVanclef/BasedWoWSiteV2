﻿namespace server.Data.Auth
{
    public partial class Logs
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public int Realm { get; set; }
        public string Type { get; set; }
        public byte Level { get; set; }
        public string String { get; set; }
    }
}
