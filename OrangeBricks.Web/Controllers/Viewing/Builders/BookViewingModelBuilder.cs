using AutoMapper;
using OrangeBricks.Web.Controllers.GenericBuilder;
using OrangeBricks.Web.Controllers.Property;
using OrangeBricks.Web.Controllers.Viewing.Commands;
using OrangeBricks.Web.Controllers.Viewing.ViewModels;
using OrangeBricks.Web.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Viewing.Builders
{
    public class BookViewingModelBuilder : IViewModelBuilderInput<PropertyController, BookViewingPropertyViewModel, BookViewingBuilderParam>
    {     

        public BookViewingPropertyViewModel Build(PropertyController controller, BookViewingPropertyViewModel viewModel, BookViewingBuilderParam input)
        {

            viewModel = Mapper.Map<BookViewingPropertyViewModel>(input);
            viewModel.ViewingDateTime = DateTime.Now.AddDays(1);
            
            return viewModel;
        }
    }
}