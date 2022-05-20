﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Core.Messages.CommonMessages.Notifications
{
    public class DomainNotification : Message, INotification
    {
        public DateTime TimeStamp { get;private set; }
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key,string value)
        {
            TimeStamp = DateTime.Now;
            Key = key; 
            Value = value;
            Version = 1;
            DomainNotificationId = Guid.NewGuid();
        }
    }
}
