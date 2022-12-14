using Microservice.Events.MessageSubscriber.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Events.Order.Worker
{
    public class OrderServiceRunner
    {
        private ISubscriber _subscriber;

        public OrderServiceRunner(ISubscriber subscriber)
        {
            _subscriber = subscriber;
        }

        public void Start() {
            Logger.LogInfo($"Order Service Started");
            _subscriber.Subscribe();
        }

        public void Stop() {
            Logger.LogInfo($"Order Service Stopped");
        }
    }
}
