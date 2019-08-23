﻿namespace NServiceBus.AzureFunctions.AzureServiceBus
{
    using Serverless;

    /// <summary>
    /// Represents a serverless NServiceBus endpoint running within an AzureServiceBus trigger.
    /// </summary>
    public class AzureServiceBusTriggeredEndpointConfiguration : ServerlessEndpointConfiguration
    {
        /// <summary>
        /// Creates a serverless NServiceBus endpoint running within an AzureServiceBus trigger.
        /// </summary>
        /// <param name="endpointName"></param>
        public AzureServiceBusTriggeredEndpointConfiguration(string endpointName) : base(endpointName)
        {
            //handle retries by native queue capabilities
            InMemoryRetries(0);
        }
    }
}