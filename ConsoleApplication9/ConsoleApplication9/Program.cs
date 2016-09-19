using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
  class Program
  {
        static void Main(string[] args)
        {
            Ticker ticker = new Ticker(2000); //.Tick delegate is NULL/empty at the moment
            AListener alistener = new AListener(0);
            alistener.Listen(ticker);//now .Tick delegate is assigned a target-method "onTickCallThis()"

            AListener alistener2 = new AListener(1);
            alistener2.Listen(ticker);


            //before .Begin() .Tick must be assigned at least one target-method so that it's not NULL. It's achieved by alistener.Listen(ticker)
            ticker.Begin();
        }
    }
}
