using OrangeBricks.Web.Controllers.GenericBuilder;

using OrangeBricks.Web.Controllers.Viewing.ViewModels;
using OrangeBricks.Web.Models;
using OrangeBricks.Web.UoW;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Viewing.Commands
{
    public class BookViewingCommandHandler
    {

        private readonly IUnitOfWork _uow;
        

        public BookViewingCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Handle(BookViewingCommand tcmdType)
        {
            using (_uow)
            {
                // This need automapping
                _uow.ViewingRepository.Add(new Models.Viewing()
                {
                    BuyerId = tcmdType.BuyerId,
                    PropertyID = tcmdType.PropertyId,
                    ViewingtDateTime = tcmdType.ViewingDateTime,
                    ViewStatusId = 2, //default 
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                });
                _uow.Commit();

            }
        }

    
    }
}