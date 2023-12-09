using MassTransit;
using RabbitMQ.Client;

namespace HomeIoTDevices.Service.Consumers.DeviceInitializedConsumer
{
    public class DeviceInitializedConsumerDefinition : ConsumerDefinition<DeviceInitializedConsumer>
    {
        public DeviceInitializedConsumerDefinition()
        {}

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<DeviceInitializedConsumer> consumerConfigurator)
        {            
            endpointConfigurator.ConfigureConsumeTopology = false;
            endpointConfigurator.ClearSerialization();
            endpointConfigurator.UseRawJsonSerializer();

            if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rabbitMq)
            {
                rabbitMq.SetQueueArgument("x-max-length", 1);
                rabbitMq.SetQueueArgument("x-overflow", "drop-head");
                rabbitMq.Bind("amq.topic", e => 
                {
                    e.RoutingKey = "device-initialized-event";
                    e.ExchangeType = ExchangeType.Topic;
                });
            }
        }
    }
}
