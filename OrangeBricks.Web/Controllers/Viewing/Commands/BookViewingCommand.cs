using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Viewing.Commands
{
    public class BookViewingCommand
    {
        public string BuyerId { get; set; }

        public DateTime ViewingDateTime { get; set; }
       
        public int PropertyId { get; set; }

        public string PropertyTitle { get; set; }

        public string ViewStatusID { get; set; }
    }
}