# Rebus.Ceras

[![install from nuget](https://img.shields.io/nuget/v/Rebus.Ceras.svg?style=flat-square)](https://www.nuget.org/packages/Rebus.Ceras)

Provides a [Ceras](https://github.com/rikimaru0345/Ceras) serializer for [Rebus](https://github.com/rebus-org/Rebus).

![](https://raw.githubusercontent.com/rebus-org/Rebus/master/artwork/little_rebusbus2_copy-200x200.png)

---

It's just

```csharp
services.AddRebus(
    configure => configure
        .(...)
        .Serialization(s => s.UseCeras())
);
```

and then Rebus is using Ceras to serialize/deserialize messages.

The `rbs2-content-type` header will be populated with the value `application/x-ceras`.