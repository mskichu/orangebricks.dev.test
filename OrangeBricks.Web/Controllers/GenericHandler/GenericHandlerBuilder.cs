using OrangeBricks.Web.Controllers.GenericHandler;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.GenericHandler
{

    public interface IGenericHandlerFactory
    {
        void HandleCommand<TController,TCommandParam>(TController controller, TCommandParam commadParam);        
    }

    public class GenericHandlerBuilderFactory : IGenericHandlerFactory
    {

        private readonly Container container;

        public GenericHandlerBuilderFactory(Container cont)
        {
            container = cont;
        }

        public void HandleCommand<TController, TCommandParam>(TController controller, TCommandParam commadParam)
        {
            IHandler<TController, TCommandParam> commandBuilder = container.GetInstance<IHandler<TController, TCommandParam>>();
            // Execute the command
           commandBuilder.Handle(commadParam);
        }
    }
}