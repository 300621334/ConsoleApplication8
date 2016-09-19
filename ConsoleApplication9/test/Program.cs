using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //sender a = new sender();
            //listener b = new listener();
            //b.Listens(a);
            //a.start();


            //instead of three classes, ALL built in once class :-)
            BothSenderAndListener x = new BothSenderAndListener();
            x.Listens(); //assigns targetMethod(s) to delegate. This has to go BEforE start() otherwise delegate will be empty/null.
            x.start();//fires event. Can create if() to check if delegate is NOT null/empty

        }
    }


    //make 4 things: (1)Delegate (2) Listener to initialize delegate e handlers (3)Handlers (4)startCalling delegate.
    internal class BothSenderAndListener
    {
        public BothSenderAndListener() { }//constructor. Optional, as VS auto generates a default one.
        public EventHandler Delegate;

        internal void start()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                Delegate(this, EventArgs.Empty);



                ////we could do sth like below in case start() is called BEFORE Listens() inside main()
                //if(Delegate == null)
                //{ Listens(); }
                //else
                //{Delegate(this, EventArgs.Empty);}
            }
        }

        internal void Listens()
        {
            Delegate += handler;
            Delegate += handler2;
            Delegate += handler3;
        }

        public void handler(object sender, EventArgs e)//tergetMethod that handles event
        {
            Console.WriteLine("click");
        }

        public void handler2(object sender, EventArgs e)
        {
            Console.WriteLine("tick");
        }

        public void handler3(object sender, EventArgs e)
        {
            Console.WriteLine("****************");
        }



    }








    internal class sender
    {
        //if want to send some info e event, create a class "customEvent" & instantiate it inside start() which will be our 2nd param. 
        //create delegate of EventHandler<customEvent> type. <> indicate what will be our 2nd param to Delegate & to handler/target method. 
        //in which case, inside start() call Delegate(this, customEventObject)


        public EventHandler Delegate;//delegate of this type take 2 params(Object sender, EventArgs e)
        public sender() { }//constructor
        internal void start()
        {
            while (true)//causes ongoing clicks.
            {
                System.Threading.Thread.Sleep(1000);
                Delegate(this, EventArgs.Empty);
            }
        }
    }




    internal class listener
    {
        public listener() { }//constructor.

        internal void Listens(sender a)
        {
            a.Delegate += handler;
            a.Delegate += handler2;
            a.Delegate += handler3;
        }


        public void handler(object sender, EventArgs e)
        //if write (sender sender,... ) instead of object sender,   get err "No overload of handler matches delegate EventHandler" coz Eventhandler takes (object sender, ...) as arg NOT (sender sender, ...)
        {
            Console.WriteLine("click");
        }

        public void handler2(object sender, EventArgs e)
        {
            Console.WriteLine("tick");
        }

        public void handler3(object sender, EventArgs e)
        {
            Console.WriteLine("****************");
        }

    }

    //instructions:
    //create main() 1st. Right-click>>Quick Actions>>create class(NOT in new file)>>
    //Then write handler method. >>> then assign that handler to delegate inside Listens>>rightclick>>Quick Act>>create delegate field.
    //change delegate to EventHandler type.
    //make start() insde sender to call Delegate() & use EventArgs.Empty as 2nd arg;

}
