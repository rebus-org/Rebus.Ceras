using System;
using System.Threading.Tasks;
using Ceras;
using Rebus.Extensions;
using Rebus.Messages;
using Rebus.Serialization;

#pragma warning disable 1998

namespace Rebus.Ceras
{
    /// <summary>
    /// Rebus serializer that uses the binary Ceras serializer to provide a robust POCO serialization that supports everything that you would expect from a modern serializer
    /// </summary>
    class RebusCerasSerializer : ISerializer
    {
        /// <summary>
        /// Mime type for Ceras
        /// </summary>
        public const string CerasContentType = "application/x-ceras";

        readonly CerasSerializer _serializer = new CerasSerializer();

        /// <summary>
        /// Serializes the given <see cref="Message"/> into a <see cref="TransportMessage"/> using the Ceras format,
        /// adding a <see cref="Headers.ContentType"/> header with the value of <see cref="CerasContentType"/>
        /// </summary>
        public async Task<TransportMessage> Serialize(Message message)
        {
            var bytes = _serializer.Serialize(message.Body);
            var headers = message.Headers.Clone();

            headers[Headers.ContentType] = CerasContentType;

            return new TransportMessage(headers, bytes);
        }

        /// <summary>
        /// Deserializes the given <see cref="TransportMessage"/> back into a <see cref="Message"/>. Expects a
        /// <see cref="Headers.ContentType"/> header with a value of <see cref="CerasContentType"/>, otherwise
        /// it will not attempt to deserialize the message.
        /// </summary>
        public async Task<Message> Deserialize(TransportMessage transportMessage)
        {
            var contentType = transportMessage.Headers.GetValue(Headers.ContentType);

            if (contentType != CerasContentType)
            {
                throw new FormatException($"Unknown content type: '{contentType}' - must be '{CerasContentType}' for the JSON serialier to work");
            }

            var body = _serializer.Deserialize<object>(transportMessage.Body);

            return new Message(transportMessage.Headers.Clone(), body);
        }
    }
}
