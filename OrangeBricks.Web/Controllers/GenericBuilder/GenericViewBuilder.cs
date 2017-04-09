using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;


namespace OrangeBricks.Web.Controllers.GenericBuilder
{

    public interface IViewModelBuilderInput<TController, TViewModel, TInput>
    {
        TViewModel Build(TController controller, TViewModel viewModel, TInput input);
    }
    public interface IViewModelBuilder<TController, TViewModel>
    {
        TViewModel Build(TController controller, TViewModel viewModel);
    }
    public interface IViewModelFactory
    {
        TViewModel GetViewModel<TController, TViewModel>(TController controller);
        TViewModel GetViewModel<TController, TViewModel, TInput>(TController controller, TInput data);
    }

    public class GenericViewModelFactory : IViewModelFactory
    {

        private readonly Container container;

        public GenericViewModelFactory(Container cont)
        {
            container = cont;
        }

        public TViewModel GetViewModel<TController, TViewModel>(TController controller)
        {

            TViewModel model;
            IViewModelBuilder<TController, TViewModel> modelBuilder;
            // Use the given Dependency Injection to create 
            //Container container = (Container)System.Web.Mvc.DependencyResolver.Current;
            model = (TViewModel)container.GetInstance(typeof(TViewModel));
            modelBuilder = container.GetInstance<IViewModelBuilder<TController, TViewModel>>();

            if (modelBuilder == null)
                throw new Exception(
                    String.Format(
                        "Could not find a ModelBuilder with a {0} Controller/{1} ViewModel pairing. Please create one.",
                        typeof(TController).Name, typeof(TViewModel).Name));

            return modelBuilder.Build(controller, model);



        }


        public TViewModel GetViewModel<TController, TViewModel, TInput>(TController controller, TInput data)
        {
            TViewModel model;
            IViewModelBuilderInput<TController, TViewModel, TInput> modelBuilder;
            // Use the given Dependency Injection to create 
         
            model = (TViewModel)container.GetInstance(typeof(TViewModel));
            modelBuilder = container.GetInstance<IViewModelBuilderInput<TController, TViewModel,TInput>>();
            // Redirect and assist developers in adding their own modelbuilder/viewmodel
            if (modelBuilder == null)
                throw new Exception(String.Format( "Could not find a ModelBuilder with a {0} Controller/{1} ViewModel/{2} TInput pairing. Please create one.",
                        typeof(TController).Name, typeof(TViewModel).Name, typeof(TInput).Name));
            // if (model == null) return null;
            return modelBuilder.Build(controller, model, data);
        }
    }



  
}