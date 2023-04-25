using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ExceptionResult
    {
        public DateTime Timestamp =>DateTime.Now;
        public string Type  { get; set; }
        public string Message    { get; set; }
    }
}
