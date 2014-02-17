using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Services.Storage;
using Services.Web;

namespace SampleWindows8App.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IStorageService, ServicesWindows8.Storage.StorageService>();
            SimpleIoc.Default.Register<IJeuxForainsAPIService, Services.Web.JeuxForainsAPIService>();
            //register other services

            SimpleIoc.Default.Register<MainViewModel>();
            //register other view models
        }


        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

       
        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}
