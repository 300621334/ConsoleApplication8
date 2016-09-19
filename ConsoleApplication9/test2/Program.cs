using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            sender a = new sender();
            listener b = new listener();
            b.Listens(a);
            a.startSending();

        }






    }



    internal class listener //Listens to assign Delegate & Handlers
    {
        internal void Listens(sender a)
        {
            a.Delegate += handler;
        }

        private void handler(object sender, customEventArgs e)
        {
            Console.WriteLine("{0}", e.time);
        }
    }

    internal class sender //Delegate & SstartSending();
    {
        internal EventHandler<customEventArgs> Delegate; //custom 2nd param for Delegate

        internal void startSending()
        {
            customEventArgs customEvent = new customEventArgs();  //new
            
            while (true)
            {
                customEvent.time = DateTime.Now;
                System.Threading.Thread.Sleep(1000);
                Delegate(this, customEvent);
            }
        }
    }


    //cuctomized EventArgs
    internal class customEventArgs : EventArgs
    {
        public DateTime time { get; set; }
    }
}

