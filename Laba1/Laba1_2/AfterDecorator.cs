﻿using Laba1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_2
{
    public class AfterAppender : AbstractDecorator
    {
        private string _text;

        public AfterAppender(IComponent component, string text) : base(component)
        {
            _text = text;
        }
        public override string operation()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this._component.operation());
            sb.Append(this._text);
            return sb.ToString();
        }
    }
}