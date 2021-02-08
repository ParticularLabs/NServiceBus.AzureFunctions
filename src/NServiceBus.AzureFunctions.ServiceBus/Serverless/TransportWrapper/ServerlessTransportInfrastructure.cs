﻿namespace NServiceBus.AzureFunctions.ServiceBus
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Transport;

    class ServerlessTransportInfrastructure : TransportInfrastructure
    {
        public ServerlessTransportInfrastructure(
            TransportInfrastructure baseTransportInfrastructure,
            ReadOnlyCollection<IMessageReceiver> receiverSettings)
        {
            this.baseTransportInfrastructure = baseTransportInfrastructure;

            Dispatcher = baseTransportInfrastructure.Dispatcher;

            var receivers = receiverSettings
                .Select(r => new PipelineInvoker(r))
                .ToArray();
            // ReSharper disable once CoVariantArrayConversion
            Receivers = new ReadOnlyCollection<IMessageReceiver>(receivers);
        }

        public override Task DisposeAsync() => baseTransportInfrastructure.DisposeAsync();


        readonly TransportInfrastructure baseTransportInfrastructure;
    }
}