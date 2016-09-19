using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{

    //class representing 2nd param to tatgetMethod(EventHandler) i.e.event onject:
    public class TickerTimeEventArgs : EventArgs //an event class that'll be used as 2nd param to eventHandler i.e. targetMethod
    {
        public DateTime Time { get; set; }
        //creating an event that does contain some data(Time) rather than an empty EventArgs.Empty. 
        //http://www.codeproject.com/Articles/22689/Creating-EventArgs-Using-Generics
    }



    //class representing 1st param 'this' to targetMethod(EventHandler) i.e.  sesnder object:
    public class Ticker //"publishing class" that generates events.
        {
        /*normally delegate-EventHandler takes an event-EventArgs that has ONLY one static field EventArgs.Empty.
        *but if we need to pass-on some info like Time along e event, then we have to make a child-class of EventArgs.
        *If using EventArgs.Empty, the inbuilt delegate "EventHandler" takes 2 params(obj Sender &  EventArgs e).
        * But since we created a child-class to deliver Time info, we cannot just use EventArgs as a param.
        * EventArgs obj 'e' has e.Empty ONLY. While TickerTimeEventArgs obj 'e' would also have e.Time in addition to e.Empty
        * We need to use child-class-type containing Time. So c# has inbuilt overload of delegate-EventHandler.
        * That overload of delegate(EventHandler) allows "generic type <TEventArgs>" offering flexibility for ONLY the 2nd param of EventHandler-delegate. Not the 1st param sender object, 1st is always an 'object'.
        * So 2nd param could be of any user-defined-type w is child-of-EventArgs.
        *Below angle brackets contain type of 2nd param for delegate-EventHandler. 1st is always an 'object'*/

        public EventHandler<TickerTimeEventArgs> Tick; //built-in delegate-field of type 'EventHandler's-child=TickerTimeEventArgs'.
        //SBS-381 "Generics"
        //If use word "event" like "public event EventHandler<TickerTimeEventArgs> Tick;" then in other class "AListener" have to do "ticker.Tick +=new EventHandler<TickerTimeEventArgs>(OnTickCallThis);".
        //"event" causes target-method to be encapsulated inside delegate(s). So have to assign delegate(targetMethod) to Tick. Rather than assigning naked targetMethod directly.



        public Ticker(int IntervalBetweenTicks)
        {
            Interval = IntervalBetweenTicks;
        }
        
        public void Begin()
        {
            if (Interval == 0)
            {
                Console.WriteLine("This interval must be greater than 0.");
                return; //or break;
            }
            while (true)
            {
                System.Threading.Thread.Sleep(Interval);//causes code to stop for 'interval' milliseconds.
                if (Tick != null)//delegate-Tick does have some targetMethod assigned to it.
                {
                    TickerTimeEventArgs tickerTimeEventArgs = new TickerTimeEventArgs();//default constructor creates obj of some event-type
                    tickerTimeEventArgs.Time = DateTime.Now;
                    Tick(this, tickerTimeEventArgs);//params sent to .Tick delegate are forwarded to 'onTickCallThis' sender obj & eventClass obj containing time info.
                }
            }
        }




        //public EventHandler aTick;
        //public void aBegin()
        //{
            
        //            aTick(this, EventArgs.Empty);//params sent to .Tick delegate are forwarded to 'onTickCallThis' sender obj & eventClass obj containing time info.
                
           
        //}


        public int Interval { get; protected set; }
            
        }
}
