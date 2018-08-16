using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnAutoMapperBug.Models {

    public class ModelB : PropertyChangedBase {

        #region Properties

        public string Name {
            get => name;
            set {
                if (name == value)
                    return;

                name = value;
                NotifyOfPropertyChange();
            }
        }

        private string name;

        #endregion

    }

}
