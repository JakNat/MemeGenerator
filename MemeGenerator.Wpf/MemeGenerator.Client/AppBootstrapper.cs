using Caliburn.Micro;
using DalSoft.RestClient.DependencyInjection;
using MemeGenerator.Client.Services;
using MemeGenerator.Client.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MemeGenerator.Client
{
    /// <summary>
    /// MemeGenerator app contener
    /// framework: Caliburn.Micro simpleContainer
    /// </summary>
    public class AppBootstrapper : BootstrapperBase
    {
        private SimpleContainer container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();


            var settings = new RestClientSetting()
            {
                address = "http://localhost:5000"
            };
            container.RegisterInstance(typeof(RestClientSetting), null, settings);
            container.PerRequest<IRestClientApp, RestClientApp>();


            container.PerRequest<IMemeService, MemeService>();
            container.PerRequest<IAuthService, AuthService>();


            #region view models
            container.PerRequest<ShellViewModel>();
            container.PerRequest<LoginViewModel>();
            container.PerRequest<ConnectionViewModel>();
            container.PerRequest<RegisterViewModel>();
            container.PerRequest<MemeLibraryViewModel>();
            container.PerRequest<MemeCreatorViewModel>();
            #endregion

        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

    }
}
