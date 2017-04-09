using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeBricks.Web.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Offer> OfferRepository { get; }
        IGenericRepository<Property> PropertyRepository { get; }
        IGenericRepository<Viewing> ViewingRepository { get; }

        IGenericRepository<ViewStatus> ViewStatusRepository { get; }


        void Commit();
    }
}
