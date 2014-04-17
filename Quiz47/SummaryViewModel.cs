using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz47
{
   public class SummaryViewModel
    {
       public Int64 totalQuestion { get; set; }
       public Int64 totalCorrect { get; set; }
       public Int64 totalWrong { get; set; }
       public Decimal percentage { get; set; }


    }
}
