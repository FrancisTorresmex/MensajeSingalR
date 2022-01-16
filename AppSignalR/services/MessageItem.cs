using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSignalR.services
{
    public class MessageItem
    {
        public string Message { get; set; }
        public int SourceId { get; set; }
        public int  TargetId { get; set; }
    }
}
