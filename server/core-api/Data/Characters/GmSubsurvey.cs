using System;
using System.Collections.Generic;

namespace server.Data.Characters
{
    public partial class GmSubsurvey
    {
        public int SurveyId { get; set; }
        public int QuestionId { get; set; }
        public int Answer { get; set; }
        public string AnswerComment { get; set; }
    }
}
