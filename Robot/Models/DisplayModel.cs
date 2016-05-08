using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Models
{
    public class DisplayModel : IDisplayModel
    {
        public string EventName { get; set; }        
        public TimeModel Time { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
}
