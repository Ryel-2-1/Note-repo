using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.Data
{
    public class UserName
    {
        private string uname = "Ryel";

        public string Name
        {
            get { return uname; }
            set
            {
                if (value.Length >= 2 && value.Length <= 64)
                {
                    uname = value;
                }
            }
        }

        public List<string> Notes { get; set; } = new List<string>();
    }
}
