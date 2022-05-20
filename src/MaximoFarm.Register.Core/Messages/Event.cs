using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        public DateTime TimeStamp { get;private set; }

        public Event()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
