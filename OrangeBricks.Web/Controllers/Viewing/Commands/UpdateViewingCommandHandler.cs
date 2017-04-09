using OrangeBricks.Web.Controllers.GenericHandler;
using OrangeBricks.Web.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Viewing.Commands
{


   
    public class UpdateViewingCommandHandler: IHandler<ViewingController, UpdateViewingCommand>
    {
        private readonly IUnitOfWork _uow;


        public UpdateViewingCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Handle(UpdateViewingCommand tcmdType)
        {
            using (_uow)
            {
                // This need automapping
                var viewings = _uow.ViewingRepository.Find(k => k.PropertyID.Equals(tcmdType.PropertyId) && k.BuyerId.Equals(tcmdType.BuyerId)).FirstOrDefault();
                viewings.ViewStatusId = tcmdType.ViewStatus;
                _uow.Commit();

            }
        }

    }
}