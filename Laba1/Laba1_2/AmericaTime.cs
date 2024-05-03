using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_2
{
    public class AmericaTime : IComponent
    {
        private CultureInfo culture;
        public AmericaTime()
        {
            culture = new CultureInfo("en-US");
        }
        public string operation()
        {
            return DateTime.Now.ToString(this.culture);
        }
    }
}