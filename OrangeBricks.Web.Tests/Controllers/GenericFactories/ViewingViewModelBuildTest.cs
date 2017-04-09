using NSubstitute;
using NUnit.Framework;
using OrangeBricks.Web.Controllers.GenericBuilder;
using OrangeBricks.Web.Controllers.GenericHandler;
using OrangeBricks.Web.Controllers.Viewing;
using OrangeBricks.Web.Controllers.Viewing.Builders;
using OrangeBricks.Web.Controllers.Viewing.Commands;
using OrangeBricks.Web.Controllers.Viewing.ViewModels;
using OrangeBricks.Web.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OrangeBricks.Web.Tests.Controllers.GenericFactories
{
    [TestFixture]
    public class ViewingViewModelBuildTest
    {

        private  IViewModelFactory _viewFactory;
        private  IGenericHandlerFactory _handler;

        private ViewingController viewcontroller;
        private ViewPropertiesViewModel viewpropertymodel;
        private BookViewingBuilderParam bookviewbilderparam;

        [SetUp]

        public void Setup()
        {
            _viewFactory = Substitute.For<IViewModelFactory>();
            _handler = Substitute.For<IGenericHandlerFactory>();
        }


        [Test]
        public void GetAllViewForaProperty()
        {
            //Now Arrange
            viewcontroller = Substitute.For<ViewingController>(_viewFactory, _handler);
            
            viewpropertymodel = new ViewPropertiesViewModel() { PropertyTitle="test", ViewProperties = new List<BookViewingPropertyViewModel>() { new BookViewingPropertyViewModel() { PropertyId = 1, PropertyTitle = "test", ViewingDateTime = DateTime.Now, BuyerId = "some guid" } } };
           
            bookviewbilderparam = Substitute.For<BookViewingBuilderParam>();
           
            //Action
            var viewmodel=_viewFactory.GetViewModel<ViewingController, ViewPropertiesViewModel, BookViewingBuilderParam>(viewcontroller, bookviewbilderparam).Returns(viewpropertymodel);

             var actionsresult = viewcontroller.AllMyViewing(bookviewbilderparam);
            //Assert
            Assert.IsNotNull(viewmodel);

            Assert.IsNotInstanceOf<RedirectToRouteResult>(actionsresult);

        }


        [Test]
        public void TestEditView()
        {
            //Now Arrange
            viewcontroller = Substitute.For<ViewingController>(_viewFactory, _handler);

            

            var updateviewmodel = Substitute.For<UpdateViewingPropertyViewModel>();
            bookviewbilderparam = Substitute.For<BookViewingBuilderParam>();

            //Action
            var viewmodel = _viewFactory.GetViewModel<ViewingController, UpdateViewingPropertyViewModel, BookViewingBuilderParam>(viewcontroller, bookviewbilderparam).Returns(updateviewmodel);
           
            var actionsresult = viewcontroller.EditView(bookviewbilderparam);
            //Assert
            Assert.That(viewmodel != null);
            Assert.IsNotInstanceOf<RedirectToRouteResult>(actionsresult);
        }
                
    }
}
