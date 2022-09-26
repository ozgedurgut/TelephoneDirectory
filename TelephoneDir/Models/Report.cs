using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelephoneDir.Models
{
    public class Report
    {

        public int id { get; set; }
        public DateTime time { get; set; }
        
        public Boolean status { get; set; } //0 is pending 1 is ready

        public ReportDetail detail { get; set; }



    }


}
