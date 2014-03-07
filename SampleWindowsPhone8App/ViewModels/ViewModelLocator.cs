using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Services.Manager;
using Services.Storage;
using Services.Web;

namespace SampleWindowsPhone8App.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (!ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IStorageService, ServicesWindowsPhone8.Storage.StorageService>();
                SimpleIoc.Default.Register<IJeuxForainsAPIService, Services.Web.JeuxForainsAPIOpenDataService>();

                DataManager.Instance.Initialize((IStorageService)SimpleIoc.Default.GetInstance(typeof(IStorageService)), (IJeuxForainsAPIService)SimpleIoc.Default.GetInstance(typeof(IJeuxForainsAPIService)));
                //register other services
            }
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
