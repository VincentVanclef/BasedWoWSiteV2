using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class GmSurvey
    {
        public int SurveyId { get; set; }
        public int Guid { get; set; }
        public int MainSurvey { get; set; }
        public string Comment { get; set; }
        public int CreateTime { get; set; }
    }
}
