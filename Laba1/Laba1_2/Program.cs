using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AmericaTime americaTime = new AmericaTime();
            EuropaTime europaTime = new EuropaTime();

            BeforeAppender beforeAppender = new BeforeAppender(europaTime, "lol");
            AfterAppender afterAppender = new AfterAppender(beforeAppender, "dwad");
            Console.WriteLine(afterAppender.operation());
        }
    }
}
