using Rebus.Serialization;
using Rebus.Tests.Contracts.Serialization;

namespace Rebus.Ceras.Tests
{
    public class CerasSerializerFactory : ISerializerFactory
    {
        public ISerializer GetSerializer()
        {
            return new RebusCerasSerializer();
        }
    }
}