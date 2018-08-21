using AutoMapper;
using CaliburnAutoMapperBug.Models;
using CaliburnAutoMapperBug.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CaliburnAutoMapperBug {

    internal class AppBootstrapper : BootstrapperBase {

        private SimpleContainer container;

        public AppBootstrapper()
            => Initialize();

        #region Bootstrapper

        protected override void Configure() {
            container = new SimpleContainer();
            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.PerRequest<IShell, ShellViewModel>();

            MapperConfiguration config = new MapperConfiguration(cfg => {
                cfg.CreateMap<ModelA, ModelB>();
            });

            container.RegisterInstance(
                typeof(IMapper),
                "automapper",
                config.CreateMapper()
            );
        }

        protected override object GetInstance(Type service, string key) {
            object instance = container.GetInstance(service, key);

            if (instance == null)
                throw new InvalidOperationException($"Could not locate any instances for '{service}'.");

            return instance;
        }

        protected override IEnumerable<object> GetAllInstances(Type service) =>
            container.GetAllInstances(service);

        protected override void BuildUp(object instance) =>
            container.BuildUp(instance);

        protected override void OnStartup(object sender, StartupEventArgs e)
            => DisplayRootViewFor<IShell>();

        #endregion

    }

}
