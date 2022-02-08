using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOToolActiveDirectorySynchronization.Tables
{
    public class UsersModelAD
    {
        private string wa;
        private string group;

        public UsersModelAD(string wa, string group)
        {
            this.wa = wa;
            this.group = group;
        }

        public string Wa
        {
            get { return wa; }
            set { wa = value; }
        }
        public string Group
        {
            get { return group; }
            set { group = value; }
        }
    }
}
