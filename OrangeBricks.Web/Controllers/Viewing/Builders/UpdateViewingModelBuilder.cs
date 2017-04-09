using AutoMapper;
using OrangeBricks.Web.Controllers.GenericBuilder;
using OrangeBricks.Web.Controllers.Viewing.ViewModels;
using OrangeBricks.Web.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrangeBricks.Web.Controllers.Viewing.Builders
{
    public class UpdateViewingModelBuilder : IViewModelBuilderInput<ViewingController, UpdateViewingPropertyViewModel, BookViewingBuilderParam>
    {
        private IUnitOfWork _uow;
        public UpdateViewingModelBuilder(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public UpdateViewingPropertyViewModel Build(ViewingController controller, UpdateViewingPropertyViewModel viewModel, BookViewingBuilderParam input)
        {
            


           
            using (_uow)
            {

                viewModel = _uow.ViewingRepository.Find(v => v.ViewingId.Equals(input.ViewingId) , includeProperties: "User,ViewStatus,Property").Select(k => new UpdateViewingPropertyViewModel
                {
                    ViewingDateTime = k.ViewingtDateTime,
                    BuyersName = k.User.UserName,
                    ViewStatus = k.ViewStatusId,
                    BuyerId = k.BuyerId,
                    PropertyId = k.PropertyID,
                    PropertyTitle=k.Property.StreetName
                }).FirstOrDefault();

                viewModel.ViewStatuses = _uow.ViewStatusRepository.GetAll().Select(vw => new SelectListItem() { Text = vw.StatusName, Value = vw.StatusId.ToString() }).ToList();
            }
                return viewModel;
        }
    }
}