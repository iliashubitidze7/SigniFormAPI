using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader.Utility
{
    public class Field
    {
        public int fileNumber { get; set; }
        public string type { get; set; }
        public int page { get; set; }
        public int left { get; set; }
        public int top { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public bool required { get; set; }
        public string placeholder { get; set; }
        public int fontSize { get; set; }
        public string Value { get; set; }
        public string [] possibleValues {  get; set; }
    }
}
