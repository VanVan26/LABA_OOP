using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_2
{
    public abstract class AbstractDecorator : IComponent
    {
        protected IComponent _component;

        public AbstractDecorator(IComponent component)
        {
            this._component = component;
        }
        public abstract string operation();
    }
}
