using OrangeBricks.Web.Controllers.Viewing.Builders;
using OrangeBricks.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrangeBricks.Web.Controllers.Viewing.ViewModels
{
    public class UpdateViewingPropertyViewModel:IViewModel, IMapFrom<BookViewingBuilderParam>
    {

        public string BuyerId { get; set; }

        public int PropertyId { get; set; }

        public string PropertyTitle { get; set; }
        [Display(Name = "Viewing Date & Time")]
        [DataType(DataType.DateTime)]
        public DateTime ViewingDateTime { get; set; }

        public string BuyersName { get; set; }

        public int ViewStatus { get; set; }
        
        public IEnumerable<SelectListItem> ViewStatuses { get; set; }
    }
}