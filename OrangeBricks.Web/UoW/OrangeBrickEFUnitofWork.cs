using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.UoW
{
    public class OrangeBrickEfUnitOfWork : ApplicationDbContext, IUnitOfWork
    {       

       
        public OrangeBrickEfUnitOfWork()
        {           
        }

        #region IUnitOfWork Implementation

       

        public IGenericRepository<Property> PropertyRepository
        {
            get
            {

                return new OrangeBrickGenericRepository<Property>(Properties);
            }
        }

        public IGenericRepository<Viewing> ViewingRepository
        {
            get
            {
                return new OrangeBrickGenericRepository<Viewing>(Viewing);
            }
        }

       public  IGenericRepository<Offer> OfferRepository
        {
            get
            {
                return new OrangeBrickGenericRepository<Offer>(Offers);
            }
        }

        public IGenericRepository<ViewStatus> ViewStatusRepository
        {
            get
            {
                return new OrangeBrickGenericRepository<ViewStatus>(ViewStatus);
            }
        }

        public void Commit()
        {
            this.SaveChanges();
        }               
        #endregion
    }
}
