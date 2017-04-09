using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeBricks.Web.Controllers.GenericHandler
{
    public interface IHandler< TContorller,Tcmdparam> 
    {
        void Handle(Tcmdparam tinput);
    }
}
