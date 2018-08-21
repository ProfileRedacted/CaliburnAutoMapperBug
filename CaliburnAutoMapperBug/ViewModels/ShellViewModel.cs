using AutoMapper;
using CaliburnAutoMapperBug.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnAutoMapperBug.ViewModels {

    class ShellViewModel : Screen, IShell {

        private static ModelA[] source = new[] {
            new ModelA {
                Name = "foo"
            },
            new ModelA {
                Name = "barr"
            }
        };

        public BindableCollection<ModelB> Items { get; } = new BindableCollection<ModelB>(
            IoC.Get<IMapper>().Map<ModelA[], IEnumerable<ModelB>>(source)
        );

    }

}
