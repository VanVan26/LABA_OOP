using Laba1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_2
{
    public class BeforeAppender : AbstractDecorator
    {
        private string _text;

        public BeforeAppender(IComponent component, string text) : base(component)
        {
            _text = text;
        }
        public override string operation()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this._text);
            sb.Append(this._component.operation());
            return sb.ToString();
        }
    }
}