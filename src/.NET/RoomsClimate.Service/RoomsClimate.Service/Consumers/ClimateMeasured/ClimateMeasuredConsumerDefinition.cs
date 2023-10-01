using MassTransit;
using RabbitMQ.Client;

namespace RoomsClimate.Service.Consumers.ClimateMeasured
{
    public class ClimateMeasuredConsumerDefinition : ConsumerDefinition<ClimateMeasuredConsumer>
    {
        public ClimateMeasuredConsumerDefinition()
        {}

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<ClimateMeasuredConsumer> consumerConfigurator)
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
                    e.RoutingKey = "climate-measured-event";
                    e.ExchangeType = ExchangeType.Topic;
                });
            }
        }
    }
}
