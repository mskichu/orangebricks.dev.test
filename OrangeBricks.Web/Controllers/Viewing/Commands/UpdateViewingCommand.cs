using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Viewing.Commands
{
    public class UpdateViewingCommand
    {
        public string BuyerId { get; set; }

        public int PropertyId { get; set; }

        public string PropertyTitle { get; set; }       
        public DateTime ViewingDateTime { get; set; }

        public string BuyersName { get; set; }

        public int ViewStatus { get; set; }
    }
}