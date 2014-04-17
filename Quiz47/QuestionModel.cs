using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz47
{
    public class QuestionModel
    {
        public Int64 qno { get; set; }
        public string question { get; set; }
        public string optA { get; set; }
        public string optB {get; set;}
        public string optC { get; set; }
        public string optD { get; set; }
        public string answer { get; set; }
    }
}
