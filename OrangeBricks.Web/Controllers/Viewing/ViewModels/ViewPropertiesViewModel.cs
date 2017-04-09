using OrangeBricks.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrangeBricks.Web.Controllers.Viewing.ViewModels
{
    public class ViewPropertiesViewModel: IViewModel, IMapFrom<OrangeBricks.Web.Models.Viewing>
    {   
        
       public string PropertyTitle { get; set; }     
       public List<BookViewingPropertyViewModel> ViewProperties { get; set; }

    }
}