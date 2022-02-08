using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOToolActiveDirectorySynchronization.Tables
{
    public class AdGroupsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string FullDomain { get; set; }
        public string ShortDomain { get; set; }
        public string RightsName { get; set; }
        public int Active { get; set; }
    }
}
