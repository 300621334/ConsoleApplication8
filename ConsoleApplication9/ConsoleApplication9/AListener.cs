using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
    
    public class AListener //subscribing class that receives event and handles it
    {
        public AListener(int id)
        {
            Id = id;
        }
    
        public void Listen(Ticker ticker)
        {
            //.Tick is delegate: if keyword 'event' was used before declaration of delegate, then we'd assign delegates(enclosing target-methods). But without 'event' we cnan just assign naked method "onTickCallThis"

            ticker.Tick += OnTickCallThis;//receives params(sender, event) thru delegate .Tick
            
            //coz word 'event' is NOT there before delegate "Tick" so method "OnTickCallThis" is NOT encapsulated inside delegate, rather exposed and may be directly assigned to "Tick". If write "event" before "Tick" then we have to go like below:
            //ticker.Tick += new EventHandler<TickerTimeEventArgs>(OnTickCallThis); 
            //Even if word 'event' is NOT there. above statement still works. But if 'event' is there then targetMethod cannot be assigned directly(have to instantiate delegate).
        }
        private void OnTickCallThis(Object sender, TickerTimeEventArgs e)
        {
            Console.WriteLine(string.Format("{0}: Ticker just ticked at time index {1}!", Id, e.Time));
        }
        
        public int Id { get; protected set; }
        
    }
}
