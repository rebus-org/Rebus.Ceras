using NUnit.Framework;
using Rebus.Activation;
using Rebus.Config;
using Rebus.Transport.InMem;

namespace Rebus.Ceras.Tests;

[TestFixture]
public class ReadMeSnippet
{
    [Test]
    public void METHOD()
    {
        Configure.With(new BuiltinHandlerActivator())
            .Transport(t => t.UseInMemoryTransport(new InMemNetwork(), "hey"))
            .Serialization(s => s.UseCeras())
            .Start();
    }
}