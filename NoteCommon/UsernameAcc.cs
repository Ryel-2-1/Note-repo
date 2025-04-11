using System;
using System.Collections.Generic;

namespace NoteCommon
{
    public class UserRecord
    {
        private string uname;

        public UserRecord()
        {
            Notes = new List<string>();
        }

        public string Name
        {
            get { return uname; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length >= 2 && value.Length <= 64)
                {
                    uname = value;
                }
            }
        }

        public List<string> Notes { get; set; }
    }
}
