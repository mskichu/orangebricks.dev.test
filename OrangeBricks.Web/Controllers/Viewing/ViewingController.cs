using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.GenericBuilder;
using OrangeBricks.Web.Controllers.GenericHandler;
using OrangeBricks.Web.Controllers.Viewing.Builders;
using OrangeBricks.Web.Controllers.Viewing.Commands;
using OrangeBricks.Web.Controllers.Viewing.ViewModels;
using OrangeBricks.Web.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrangeBricks.Web.Controllers.Viewing
{
    [Authorize]
    public class ViewingController:Controller
    {
        private readonly IViewModelFactory _viewFactory;
        private readonly IGenericHandlerFactory _handler;

        public ViewingController(IViewModelFactory vfactory, IGenericHandlerFactory handler)
        {

            _viewFactory = vfactory;
            _handler = handler;

        }

        [HttpGet]
        [OrangeBricksAuthorize(Roles = "Seller")]
        public ActionResult AllMyViewing(BookViewingBuilderParam viewParam)
        {
            var viewdata = _viewFactory.GetViewModel<ViewingController, ViewPropertiesViewModel, BookViewingBuilderParam>(this, viewParam);
            return View(viewdata);
        }

        [HttpGet]
        [OrangeBricksAuthorize(Roles = "Seller")]
        public ActionResult EditView(BookViewingBuilderParam viewParam)
        {
            var viewdata = _viewFactory.GetViewModel<ViewingController, UpdateViewingPropertyViewModel, BookViewingBuilderParam>(this, viewParam);
            return View(viewdata);
        }

        [HttpPost]
        [OrangeBricksAuthorize(Roles = "Seller")]
        public ActionResult EditView(UpdateViewingCommand cmdParam)
        {
            _handler.HandleCommand(this, cmdParam);

            return RedirectToAction("MyProperties", "Property");
        }






    }
}