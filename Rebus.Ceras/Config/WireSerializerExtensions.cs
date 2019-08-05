using System;
using Rebus.Ceras;
using Rebus.Serialization;
// ReSharper disable UnusedMember.Global

namespace Rebus.Config
{
    /// <summary>
    /// Configuration extensions for the Ceras serializer
    /// </summary>
    public static class CerasSerializerConfigurationExtensions
    {
        /// <summary>
        /// Configures Rebus to use the super-spiffy Ceras serializer to serialize messages
        /// </summary>
        public static void UseCeras(this StandardConfigurer<ISerializer> configurer)
        {
            if (configurer == null) throw new ArgumentNullException(nameof(configurer));

            configurer.Register(c => new RebusCerasSerializer(), 
                "Registered RebusCerasSerializer as the primary implementation of ISerializer");
        }
    }
}