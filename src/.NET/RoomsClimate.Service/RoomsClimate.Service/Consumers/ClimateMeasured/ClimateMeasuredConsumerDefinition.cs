using MassTransit;

namespace RoomsClimate.Service.Consumers.ClimateMeasured
{
    public class ClimateMeasuredConsumerDefinition : ConsumerDefinition<ClimateMeasuredConsumer>
    {
        public ClimateMeasuredConsumerDefinition()
        {
            EndpointName = "climate-measured-event";
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<ClimateMeasuredConsumer> consumerConfigurator)
        {
            endpointConfigurator.ConfigureConsumeTopology = false;
            endpointConfigurator.ClearMessageDeserializers();
            endpointConfigurator.UseRawJsonSerializer();

            if (endpointConfigurator is IRabbitMqReceiveEndpointConfigurator rabbitMq)
            {
                rabbitMq.Bind("climate-measured-event");
            }
        }
    }
}
