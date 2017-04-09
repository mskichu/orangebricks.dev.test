using System.Collections;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Controllers.Property.Builders;
using OrangeBricks.Web.Controllers.Property.Commands;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.Controllers.GenericBuilder;
using OrangeBricks.Web.Controllers.Viewing.Commands;
using OrangeBricks.Web.Controllers.Viewing.ViewModels;
using OrangeBricks.Web.UoW;
using OrangeBricks.Web.Controllers.Viewing.Builders;

namespace OrangeBricks.Web.Controllers.Property
{
    [Authorize]
    public class PropertyController : Controller
    {
        private readonly IOrangeBricksContext _context;
        private readonly IViewModelFactory _viewFactory;
        private readonly IUnitOfWork _uow;
        

        

        public PropertyController(IOrangeBricksContext context, IViewModelFactory viewFactory, IUnitOfWork uow)
        {
            _viewFactory = viewFactory;
            _context = context;
            _uow = uow;
        }

        [Authorize]
        public ActionResult Index(PropertiesQuery query)
        {
            var builder = new PropertiesViewModelBuilder(_context);
            var viewModel = builder.Build(query);

            return View(viewModel);
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        public ActionResult Create()
        {
            var viewModel = new CreatePropertyViewModel();

            viewModel.PossiblePropertyTypes = new string[] { "House", "Flat", "Bungalow" }
                .Select(x => new SelectListItem { Value = x, Text = x })
                .AsEnumerable();

            return View(viewModel);
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        [HttpPost]
        public ActionResult Create(CreatePropertyCommand command)
        {
            var handler = new CreatePropertyCommandHandler(_context);

            command.SellerUserId = User.Identity.GetUserId();

            handler.Handle(command);

            return RedirectToAction("MyProperties");
        }

        [OrangeBricksAuthorize(Roles = "Seller")]
        public ActionResult MyProperties()
        {
            var builder = new MyPropertiesViewModelBuilder(_context);
            var viewModel = builder.Build(User.Identity.GetUserId());

            return View(viewModel);
        }

        [HttpPost]
        [OrangeBricksAuthorize(Roles = "Seller")]
        public ActionResult ListForSale(ListPropertyCommand command)
        {
            var handler = new ListPropertyCommandHandler(_context);

            handler.Handle(command);

            return RedirectToAction("MyProperties");
        }

        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult MakeOffer(int id)
        {
            var builder = new MakeOfferViewModelBuilder(_context);
            var viewModel = builder.Build(id);
            return View(viewModel);
        }

        [HttpPost]
        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult MakeOffer(MakeOfferCommand command)
        {
            var handler = new MakeOfferCommandHandler(_context);

            handler.Handle(command);

            return RedirectToAction("Index");
        }

        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult BookViewing(BookViewingBuilderParam param)
        {
            param.BuyerId = this.HttpContext.User.Identity.GetUserId();
            return View(_viewFactory.GetViewModel<PropertyController, BookViewingPropertyViewModel, BookViewingBuilderParam>(this, param));
        }


        [HttpPost]
        [OrangeBricksAuthorize(Roles = "Buyer")]
        public ActionResult BookViewing(BookViewingCommand command)
        {
            command.BuyerId= this.HttpContext.User.Identity.GetUserId();
            var handler = new BookViewingCommandHandler(_uow);
            handler.Handle(command);
            return RedirectToAction("Index");
        }


    }
}