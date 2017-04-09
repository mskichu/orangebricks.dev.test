using OrangeBricks.Web.Controllers.GenericBuilder;
using OrangeBricks.Web.Controllers.Viewing.ViewModels;
using OrangeBricks.Web.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Viewing.Builders
{
    public class ListViewingModelBuilder : IViewModelBuilderInput<ViewingController, ViewPropertiesViewModel, BookViewingBuilderParam>
    {
        private readonly IUnitOfWork _uow;

        public ListViewingModelBuilder(IUnitOfWork uow)
        {
            _uow = uow;

        }

        public ViewPropertiesViewModel Build(ViewingController controller, ViewPropertiesViewModel viewModel, BookViewingBuilderParam input)
        {

            var propertieslist = new ViewPropertiesViewModel();
            using (_uow)
            {
              var viewinglist=  _uow.ViewingRepository.Find(v => v.PropertyID.Equals(input.PropertyId),includeProperties:"User,ViewStatus").Select(k=>new BookViewingPropertyViewModel
                {
                     ViewingDateTime=k.ViewingtDateTime, BuyersName=k.User.UserName,ViewStatus=k.ViewStatus.StatusName,BuyerId=k.BuyerId,
                     PropertyId=k.PropertyID, ViewingId=k.ViewingId
                }).ToList();
                var property = _uow.PropertyRepository.Find(p => p.Id.Equals(input.PropertyId)).FirstOrDefault();
                propertieslist.PropertyTitle = property.StreetName;
                propertieslist.ViewProperties = viewinglist;
            }

            return propertieslist;
        }
    }
}