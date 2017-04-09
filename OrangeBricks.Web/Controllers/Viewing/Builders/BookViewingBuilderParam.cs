using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Viewing.Builders
{
    public class BookViewingBuilderParam
    {
        public int PropertyId { get; set; }
        public string PropertyTitle { get; set; }
        public string BuyerId { get; set; }

        public string BuyersName { get; set; }

        public int ViewStatus { get; set; }
        public DateTime ViewingDateTime { get; set; }

        public int ViewingId { get; set; }
    }
}