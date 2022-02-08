using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOToolDataLibrary.Models.CustomTables
{
    public class SummaryRequestModel
    {
        public string RequestType { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime ETD { get; set; }
        public DateTime ETA { get; set; }
        public string NrPallets { get; set; }
        public string Weight { get; set; }
        public string StandardTime { get; set; }
        public string StandardPrice { get; set; }
        public string Message { get;set; }
    }
}
